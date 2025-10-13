using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using web_api.Lib.UnitOfWork;

namespace web_api.Controllers
{
	/// <summary>
	/// Controller responsible for handling authentication-related operations such as user registration, login, token refresh, and authentication testing.
	/// <para>
	/// Endpoints provided:
	/// <list type="bullet">
	///   <item><description><b>POST /api/auth/register</b>: Registers a new user with basic credentials.</description></item>
	///   <item><description><b>POST /api/auth/login</b>: Authenticates a user and returns JWT tokens.</description></item>
	///   <item><description><b>POST /api/auth/refresh</b>: Refreshes authentication tokens using a valid refresh token.</description></item>
	///   <item><description><b>GET /api/auth/test</b>: Tests authentication and returns user details from the JWT token.</description></item>
	/// </list>
	/// </para>
	/// <remarks>
	/// All endpoints except <c>GET /api/auth/test</c> are accessible without authentication.
	/// </remarks>
	/// </summary>
	[AllowAnonymous]
	[Route("api/[controller]")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IConfiguration _configuration;

		public AuthController(IUnitOfWork unitOfWork, IConfiguration configuration)
		{
			_unitOfWork = unitOfWork;
			_configuration = configuration;
		}

		/// <summary>
		/// Registers a new user with basic credentials (Name, Email, Password).
		/// This endpoint is intended for simple user registration and does not accept additional user data.
		/// To add more user information, use a different endpoint.
		/// 
		/// <para>Required fields in <see cref="RegisterDTO"/>:</para>
		/// <list type="bullet">
		///   <item><description><b>UserName</b>: string (required)</description></item>
		///   <item><description><b>Email</b>: string, must be a valid email address (required)</description></item>
		///   <item><description><b>Password</b>: string (required)</description></item>
		/// </list>
		/// </summary>
		/// <param name="registerDto">The registration data for the new user.</param>
		/// <returns>
		/// 200 OK with registration result if successful.<br/>
		/// 400 Bad Request with error message if registration fails.<br/>
		/// <br/>
		/// The response is an <see cref="AuthResponseDTO"/> object:<br/>
		/// <code>
		/// public class AuthResponseDTO
		/// {
		///     public string AccessToken { get; set; }
		///     public string RefreshToken { get; set; }
		///     public DateTime Expiration { get; set; }
		///     public Guid UserId { get; set; }
		///     public string UserName { get; set; }
		///     public string Email { get; set; }
		///     public string UserType { get; set; }
		///     public string PermissionType { get; set; }
		/// }
		/// </code>
		/// </returns>
		[HttpPost("register")]
		public async Task<IActionResult> Register([FromBody] RegisterDTO registerDto)
		{
			try
			{
				var result = await _unitOfWork.authRepository.Register(registerDto);
				return Ok(new { success = true, data = result });
			}
			catch (Exception e)
			{
				return BadRequest(new { success = false, message = e.Message });
			}
		}

		/// <summary>
		/// Authenticates a user using their email and password.
		/// 
		/// <para>Required fields in <see cref="LoginDTO"/>:</para>
		/// <list type="bullet">
		///   <item><description><b>Email</b>: string, must be a valid email address (required)</description></item>
		///   <item><description><b>Password</b>: string (required)</description></item>
		/// </list>
		/// </summary>
		/// <param name="loginDto">The login credentials for the user.</param>
		/// <returns>
		/// 200 OK with authentication result if successful.<br/>
		/// 400 Bad Request with error message if authentication fails.<br/>
		/// <br/>
		/// The response is an <see cref="AuthResponseDTO"/> object:<br/>
		/// <code>
		/// public class AuthResponseDTO
		/// {
		///     public string AccessToken { get; set; }
		///     public string RefreshToken { get; set; }
		///     public DateTime Expiration { get; set; }
		///     public Guid UserId { get; set; }
		///     public string Name { get; set; }
		///     public string Email { get; set; }
		///     public string UserType { get; set; }
		///     public string PermissionType { get; set; }
		/// }
		/// </code>
		/// </returns>
		[HttpPost("login")]
		public async Task<IActionResult> Login([FromBody] LoginDTO loginDto)
		{
			try
			{
				var result = await _unitOfWork.authRepository.Login(loginDto);
				return Ok(new { success = true, data = result });
			}
			catch (Exception e)
			{
				return BadRequest(new { success = false, message = e.Message });
			}
		}

		/// <summary>
		/// Refreshes the user's authentication tokens using a valid refresh token.
		/// 
		/// <para>Required field in <see cref="RefreshTokenDTO"/>:</para>
		/// <list type="bullet">
		///   <item><description><b>RefreshToken</b>: string (required)</description></item>
		/// </list>
		/// </summary>
		/// <param name="refreshTokenDto">The refresh token data for the user.</param>
		/// <returns>
		/// 200 OK with new authentication tokens if successful.<br/>
		/// 400 Bad Request with error message if the refresh token is invalid or expired.<br/>
		/// <br/>
		/// The response is an <see cref="AuthResponseDTO"/> object:<br/>
		/// <code>
		/// public class AuthResponseDTO
		/// {
		///     public string AccessToken { get; set; }
		///     public string RefreshToken { get; set; }
		///     public DateTime Expiration { get; set; }
		///     public Guid UserId { get; set; }
		///     public string Name { get; set; }
		///     public string Email { get; set; }
		///     public string UserType { get; set; }
		///     public string PermissionType { get; set; }
		/// }
		/// </code>
		/// </returns>
		[HttpPost("refresh")]
		public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenDTO refreshTokenDto)
		{
			try
			{
				var result = await _unitOfWork.authRepository.RefreshToken(refreshTokenDto.RefreshToken);
				return Ok(new { success = true, data = result });
			}
			catch (Exception e)
			{
				return BadRequest(new { success = false, message = e.Message });
			}
		}

		/// <summary>
		/// Test endpoint to confirm if the authentication mechanism is working.
		/// 
		/// <para>
		/// This endpoint requires a valid JWT access token in the Authorization header.
		/// If the token is valid, it returns basic user details extracted from the token.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <b>Authorization:</b> Bearer token required.<br/>
		/// <b>Response:</b>
		/// <list type="bullet">
		///   <item><description><b>message</b>: Confirmation that authentication is successful.</description></item>
		///   <item><description><b>userDetails</b>: Object containing <c>id</c>, <c>name</c>, <c>email</c>, and <c>role</c> from the token claims.</description></item>
		/// </list>
		/// </remarks>
		/// <returns>
		/// 200 OK if the token is valid, with user details.<br/>
		/// 401 Unauthorized if the token is missing or invalid.
		/// </returns>
		[HttpGet("test")]
		[Authorize]
		public IActionResult TestAuth()
		{
			var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
			var userName = User.FindFirst(ClaimTypes.Name)?.Value;
			var userEmail = User.FindFirst(ClaimTypes.Email)?.Value;
			var userRole = User.FindFirst(ClaimTypes.Role)?.Value;

			return Ok(new
			{
				message = "Authentication successful! Your token is valid.",
				userDetails = new
				{
					id = userId,
					name = userName,
					email = userEmail,
					role = userRole
				}
			});
		}
	}
}
