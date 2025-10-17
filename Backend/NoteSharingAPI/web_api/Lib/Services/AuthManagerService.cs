using Microsoft.Extensions.Caching.Distributed;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using web_api.Lib.Database;
using web_api.Lib.Services.Interfaces;

namespace web_api.Lib.Services
{
	public class AuthManagerService : IAuthManagerService
	{
		private readonly db_context _context;
		private readonly IConfiguration _configuration;
		private readonly IDistributedCache _cache;
		private readonly IServiceScopeFactory _scopeFactory;

		public AuthManagerService(db_context context, IConfiguration configuration, IDistributedCache cache, IServiceScopeFactory scopeFactory)
		{
			_context = context;
			_configuration = configuration;
			_cache = cache;
			_scopeFactory = scopeFactory;
		}

		/// <summary>
		/// Authenticates a user using the provided login credentials.
		/// Throws an exception if the credentials are invalid.
		/// </summary>
		/// <param name="loginDto">Login credentials (email and password).</param>
		/// <returns>Authentication response containing tokens and user info.</returns>
		public async Task<AuthResponseDTO> Login(LoginDTO loginDto)
		{
			var user = await _context.Users
				.FirstOrDefaultAsync(u => u.Email == loginDto.Email && u.Enabled);

			if (user == null || !VerifyPassword(loginDto.Password, user.Password))
			{
				if (user != null) {
					await Log(message: "User login unsucsessful: Invalid credentials", UserId: user.ID.ToString());
				}
				else
				{
					await Log(message: "User login unsucsessful: No matching user");
				}

				throw new Exception("Invalid email or password");
			}

			await Log(message: "User logged in", UserId: user.ID.ToString());

			return await GenerateTokensForUser(user);
		}

		/// <summary>
		/// Registers a new user with the provided registration details.
		/// Throws an exception if the email or username is already taken.
		/// </summary>
		/// <param name="registerDto">Registration details (username, email, password).</param>
		/// <returns>Authentication response containing tokens and user info.</returns>
		public async Task<AuthResponseDTO> Register(RegisterDTO registerDto)
		{
			if (await _context.Users.AnyAsync(u => u.Email == registerDto.Email))
			{
				await Log(message: "User register unsucsessful: Email already in use");
				throw new Exception("Email already registered");
			}
			if(await _context.Users.AnyAsync(u => u.UserName == registerDto.UserName))
			{
				await Log(message: "User register unsucsessful: Username already in use");
				throw new Exception("Username already taken");
			}

			var preference = new Preference();

			var user = new User
			{
				ID = Guid.NewGuid(),
				UserName = registerDto.UserName,
				Email = registerDto.Email,
				Password = HashPassword(registerDto.Password),
				UserType = EUserType.Default,
				PermissionType = EPermissionType.User,
				PreferenceID = preference.ID,
				Name = registerDto.UserName,
				InstitutionID = null,
				Grade = null,
				Description = null,
				Enabled = true
			};

			await CreatePreference(preference);
			await CreateUser(user);

			await Log(message: "User registered", UserId: user.ID.ToString());

			return await GenerateTokensForUser(user);
		}

		/// <summary>
		/// Creates a new user in the database within a transaction.
		/// Removes the "users" cache entry after creation.
		/// Throws an exception if user creation fails.
		/// </summary>
		/// <param name="user">User entity to create.</param>
		private async Task CreateUser(User user)
		{
			var transaction = await _context.Database.BeginTransactionAsync();
			try
			{
				await _context.Users.AddAsync(user);
				await _context.SaveChangesAsync();
				await _cache.RemoveAsync("users");
				await transaction.CommitAsync();
			}
			catch (Exception ex)
			{
				await transaction.RollbackAsync();
				await Log(message: $"User register unsucsessful: An error occured while creating the user: {ex.InnerException}");
				throw new Exception("Error creating user: " + ex.Message);
			}
			finally
			{
				await transaction.DisposeAsync();
			}
		}

		/// <summary>
		/// Creates a new <see cref="Preference"/> entity in the database within a transaction.
		/// Commits the transaction if the operation is successful; otherwise, rolls back the transaction and logs the error.
		/// Throws an exception if the creation fails.
		/// </summary>
		/// <param name="preference">
		/// The <see cref="Preference"/> entity to be created and persisted in the database.
		/// </param>
		/// <exception cref="Exception">
		/// Thrown when an error occurs during the creation of the <see cref="Preference"/> entity.
		/// The exception message contains details about the error.
		/// </exception>
		/// <remarks>
		/// This method ensures that the creation of the <see cref="Preference"/> entity is atomic by using a database transaction.
		/// If an error occurs, the transaction is rolled back and a log entry is created with severity <see cref="ESeverity.Error"/>.
		/// </remarks>
		private async Task CreatePreference(Preference preference)
		{
			var transaction = await _context.Database.BeginTransactionAsync();
			try
			{
				await _context.Preferences.AddAsync(preference);
				await _context.SaveChangesAsync();
				await transaction.CommitAsync();
			}
			catch (Exception ex)
			{
				await transaction.RollbackAsync();
				await Log(message: "Preference create unsucsessful: An error occured while creating the user preference");
				throw new Exception("Error creating user preference: " + ex.Message);
			}
			finally
			{
				await transaction.DisposeAsync();
			}
		}

		/// <summary>
		/// Refreshes the authentication tokens using a valid refresh token.
		/// Throws an exception if the token is invalid or expired.
		/// </summary>
		/// <param name="token">Refresh token.</param>
		/// <returns>Authentication response containing new tokens and user info.</returns>
		public async Task<AuthResponseDTO> RefreshToken(string token)
		{
			var transaction = await _context.Database.BeginTransactionAsync();

			var user = await _context.Users
				.FirstOrDefaultAsync(u => u.RefreshToken == token && u.RefreshTokenExpires > DateTime.UtcNow && u.Enabled);

			if (user == null)
			{
				await Log(message: "Refreshing token for user unsucsessful: Invalid or expired refresh token");
				throw new Exception("Invalid or expired refresh token");
			}

			await Log(message: "Refresh user token", UserId: user.ID.ToString());

			return await GenerateTokensForUser(user);
		}

		/// <summary>
		/// Generates new access and refresh tokens for the specified user.
		/// Updates the user's refresh token and expiration in the database.
		/// </summary>
		/// <param name="user">User entity.</param>
		/// <returns>Authentication response containing tokens and user info.</returns>
		private async Task<AuthResponseDTO> GenerateTokensForUser(User user)
		{
			var accessToken = GenerateJwtToken(user);
			var refreshToken = GenerateRefreshToken();

			user.RefreshToken = refreshToken;
			user.RefreshTokenExpires = DateTime.UtcNow.AddDays(Convert.ToDouble(_configuration["JwtSettings:RefreshTokenExpiryDays"]));

			await _context.SaveChangesAsync();

			return new AuthResponseDTO
			{
				AccessToken = accessToken,
				RefreshToken = refreshToken,
				Expiration = DateTime.UtcNow.AddMinutes(Convert.ToDouble(_configuration["JwtSettings:AccessTokenExpiryMinutes"])),
				UserId = user.ID,
				Name = user.Name,
				Email = user.Email,
				UserType = user.UserType.ToString()
			};
		}

		/// <summary>
		/// Generates a JWT access token for the specified user.
		/// </summary>
		/// <param name="user">User entity.</param>
		/// <returns>JWT access token string.</returns>
		private string GenerateJwtToken(User user)
		{
			var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:SecretKey"]));
			var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

			var claims = new[]
			{
				new Claim(ClaimTypes.NameIdentifier, user.ID.ToString()),
				new Claim(ClaimTypes.Name, user.Name),
				new Claim(ClaimTypes.Email, user.Email),
				new Claim(ClaimTypes.Role, user.UserType.ToString()),
				new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
			};

			var token = new JwtSecurityToken(
				issuer: _configuration["JwtSettings:Issuer"],
				audience: _configuration["JwtSettings:Audience"],
				claims: claims,
				expires: DateTime.UtcNow.AddMinutes(Convert.ToDouble(_configuration["JwtSettings:AccessTokenExpiryMinutes"])),
				signingCredentials: creds
			);

			return new JwtSecurityTokenHandler().WriteToken(token);
		}

		/// <summary>
		/// Generates a secure random refresh token.
		/// </summary>
		/// <returns>Refresh token string.</returns>
		private static string GenerateRefreshToken()
		{
			var randomNumber = new byte[64];
			using var rng = RandomNumberGenerator.Create();
			rng.GetBytes(randomNumber);
			return Convert.ToBase64String(randomNumber);
		}

		/// <summary>
		/// Hashes the provided password using BCrypt.
		/// </summary>
		/// <param name="password">Plain text password.</param>
		/// <returns>Hashed password string.</returns>
		private static string HashPassword(string password)
		{
			return BCrypt.Net.BCrypt.HashPassword(password, BCrypt.Net.BCrypt.GenerateSalt(12));
		}

		/// <summary>
		/// Verifies a password against its hashed value using BCrypt.
		/// </summary>
		/// <param name="password">Plain text password.</param>
		/// <param name="passwordHash">Hashed password.</param>
		/// <returns>True if the password matches the hash; otherwise, false.</returns>
		private static bool VerifyPassword(string password, string passwordHash)
		{
			return BCrypt.Net.BCrypt.Verify(password, passwordHash);
		}

		private async Task Log(string UserId = "System", ESeverity severity = ESeverity.Information, string message = "")
		{
			var scope = _scopeFactory.CreateScope();
			var _logManager = scope.ServiceProvider.GetRequiredService<ILogManagerService>();
			Log log = new Log()
			{
				UserId = UserId,
				Severity = severity,
				Message = message
			};
			var response = await _logManager.AddLog(log);
			scope.Dispose();
			if (response == null) {
				throw new Exception($"Couldn't log activity: '{message}'");
			}
		}
	}
}
