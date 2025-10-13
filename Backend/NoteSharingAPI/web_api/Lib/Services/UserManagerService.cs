using class_library.DTO;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using web_api.Lib.Database;
using web_api.Lib.Services.Interfaces;

namespace web_api.Lib.Services
{
    /// <summary>
    /// Provides user management operations such as update, delete, retrieval, and follow functionality.
    /// </summary>
    public class UserManagerService : IUserManagerService
    {
		private readonly db_context _dbContext;
		private readonly IDistributedCache _cache;
		private readonly IServiceScopeFactory _scopeFactory;

		/// <summary>
		/// Initializes a new instance of the <see cref="UserManagerService"/> class.
		/// </summary>
		/// <param name="dbContext">The database context for accessing user data.</param>
		/// <param name="cache">The distributed cache for caching user data.</param>
		/// <param name="scopeFactory">The service scope factory for resolving scoped services.</param>
		public UserManagerService(db_context dbContext, IDistributedCache cache, IServiceScopeFactory scopeFactory)
        {
            _dbContext = dbContext;
            _cache = cache;
            _scopeFactory = scopeFactory;
        }

        /// <summary>
        /// Retrieves all users from cache if available, otherwise from the database, and caches the result.
        /// </summary>
        /// <returns>An <see cref="IQueryable{User}"/> containing all users.</returns>
        private async Task<IQueryable<User>> querryUsers()
        {
            var cachedData = await _cache.GetStringAsync("users");
            if (!string.IsNullOrEmpty(cachedData))
            {
                var data = JsonConvert.DeserializeObject<List<User>>(cachedData);
                return data.AsQueryable();
            }
            var dataFromDb = await _dbContext.Users.OrderBy(c => c.ID).ToListAsync();
            var cacheOptions = new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10),
                SlidingExpiration = TimeSpan.FromMinutes(5)
            };

            var serializedData = JsonConvert.SerializeObject(dataFromDb);
            await _cache.SetStringAsync("users", serializedData, cacheOptions);
            return dataFromDb.AsQueryable();
        }

        /// <summary>
        /// Creates a new user in the system.
        /// </summary>
        /// <param name="dto">The data transfer object containing user creation data.</param>
        /// <returns>A <see cref="UserViewDTO"/> representing the created user.</returns>
        public Task<UserViewDTO> CreateAsync(UserCreateDTO dto)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Updates an existing user's information.
        /// </summary>
        /// <param name="dto">The data transfer object containing updated user data.</param>
        /// <returns>A <see cref="UserViewDTO"/> representing the updated user.</returns>
        /// <exception cref="KeyNotFoundException">Thrown if the user is not found.</exception>
        /// <exception cref="Exception">Thrown if an error occurs during update.</exception>
        public async Task<UserViewDTO> UpdateAsync(UserUpdateDTO dto)
        {
            var transaction = await _dbContext.Database.BeginTransactionAsync();
            try
            {
                var users = await querryUsers();
                var user = users.FirstOrDefault(u => u.ID == dto.ID);
                if (user == null)
                    throw new KeyNotFoundException($"User with ID {dto.ID} not found.");

                // Set fields if not null
                if (dto.UserName != null)
                    user.UserName = dto.UserName;
                if (dto.Name != null)
                    user.Name = dto.Name;
                if (dto.Email != null)
                    user.Email = dto.Email;
                if (dto.Password != null)
                    user.Password = dto.Password;
                // EUserType is not nullable, so always set
                user.UserType = dto.UserType;
                if (dto.InstitutionID.HasValue)
                    user.InstitutionID = dto.InstitutionID;
                if (dto.Grade != null)
                    user.Grade = dto.Grade;

                // Update in DB
                _dbContext.Users.Update(user);
                await _dbContext.SaveChangesAsync();

                // Invalidate cache
                await _cache.RemoveAsync("users");
                await transaction.CommitAsync();

                await Log(UserId: user.ID.ToString(), message: "User data updated");

                // Return DTO
                return new UserViewDTO
                {
                    ID = user.ID,
                    UserName = user.UserName,
                    Name = user.Name,
                    Email = user.Email,
                    UserType = user.UserType,
                    PreferenceID = user.PreferenceID
                };
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                await Log(UserId: dto.ID.ToString(), severity: ESeverity.Error, message: "User update unsuccessful: " + ex.Message);
                throw new Exception("Error updating user: " + ex.Message);
            }
            finally
            {
                await transaction.DisposeAsync();
            }
        }

        /// <summary>
        /// Soft deletes a user by disabling their account.
        /// </summary>
        /// <param name="id">The unique identifier of the user to delete.</param>
        /// <returns><c>true</c> if the user was deleted; otherwise, <c>false</c>.</returns>
        /// <exception cref="KeyNotFoundException">Thrown if the user is not found.</exception>
        /// <exception cref="Exception">Thrown if an error occurs during deletion.</exception>
        public async Task<bool> DeleteAsync(Guid id)
        {
            var transaction = await _dbContext.Database.BeginTransactionAsync();
            try
            {
                var users = await querryUsers();
                var user = users.FirstOrDefault(u => u.ID == id);
                if (user == null)
                    throw new KeyNotFoundException($"User with ID {id} not found.");
                user.Enabled = false; // Soft delete
                _dbContext.Users.Update(user);
                await _dbContext.SaveChangesAsync();
                // Invalidate cache
                await _cache.RemoveAsync("users");
                await transaction.CommitAsync();
                await Log(UserId: user.ID.ToString(), message: "User deleted");
				return true;
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                await Log(UserId: id.ToString(), severity: ESeverity.Error, message: "User deletion unsuccessful: " + ex.Message);
				throw new Exception("Error deleting user: " + ex.Message);
            }
            finally
            {
                await transaction.DisposeAsync();
            }
        }

        /// <summary>
        /// Retrieves a user by their unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the user to retrieve.</param>
        /// <returns>
        /// A <see cref="UserViewDTO"/> representing the user if found and enabled; otherwise, throws <see cref="KeyNotFoundException"/>.
        /// </returns>
        /// <exception cref="KeyNotFoundException">
        /// Thrown if the user with the specified <paramref name="id"/> is not found or is deleted (disabled).
        /// </exception>
		public async Task<UserViewDTO?> GetByIdAsync(Guid id)
        {
            var users = await querryUsers();
            var user = users.FirstOrDefault(u => u.ID == id);
            if (user == null)
                throw new KeyNotFoundException($"User with ID {id} not found.");
            if(!user.Enabled)
                throw new KeyNotFoundException($"User with ID {id} is deleted.");
			return user.Adapt<UserViewDTO>();
		}

        /// <summary>
        /// Retrieves a user by their username.
        /// </summary>
        /// <param name="userName">The username of the user to retrieve.</param>
        /// <returns>
        /// A <see cref="UserViewDTO"/> representing the user if found and enabled; otherwise, throws <see cref="KeyNotFoundException"/>.
        /// </returns>
        /// <exception cref="KeyNotFoundException">
        /// Thrown if the user with the specified <paramref name="userName"/> is not found or is deleted (disabled).
        /// </exception>
        public async Task<UserViewDTO?> GetByUserNameAsync(string userName)
        {
			var users = await querryUsers();
			var user = users.FirstOrDefault(u => u.UserName == userName);
			if (user == null)
				throw new KeyNotFoundException($"User with Username {userName} not found.");
			if (!user.Enabled)
				throw new KeyNotFoundException($"User with Username {userName} is deleted.");
			return user.Adapt<UserViewDTO>();
		}

        /// <summary>
        /// Retrieves all enabled users in the system.
        /// </summary>
        /// <returns>
        /// An <see cref="IEnumerable{UserViewDTO}"/> containing all enabled users.
        /// </returns>
        /// <exception cref="KeyNotFoundException">
        /// Thrown if no users are found in the system.
        /// </exception>
        public async Task<IEnumerable<UserViewDTO>> GetAllAsync()
        {
            var users = await querryUsers();
            if (users == null || !users.Any())
                throw new KeyNotFoundException("No users found.");
            return users.Where(u => u.Enabled).Select(u => u.Adapt<UserViewDTO>()).ToList();
		}

        /// <summary>
        /// Follows another user by creating a follow relationship.
        /// </summary>
        /// <param name="dto">The data transfer object containing follower and following user IDs.</param>
        /// <returns>
        /// A <see cref="Task{Boolean}"/> indicating whether the follow operation was successful.
        /// </returns>
        /// <exception cref="Exception">
        /// Thrown if an error occurs during the follow operation.
        /// </exception>
        public Task<bool> FollowAsync(UserFollowDTO dto)
        {
            var scope = _scopeFactory.CreateScope();
            var _followManager = scope.ServiceProvider.GetRequiredService<IUserFollowManagerService>();
            try
            {
                return _followManager.FollowAsync(dto);
            }
            catch (Exception ex)
            {
                throw new Exception("Error following user: " + ex.Message);
            }
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
			if (response != null)
			{
				throw new Exception($"Couldn't log activity: '{message}'");
			}
		}
	}
}
