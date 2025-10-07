using class_library.DTO;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using web_api.Lib.Database;
using web_api.Lib.Services.Interfaces;

namespace web_api.Lib.Services
{
    public class UserManagerService : IUserManagerService
    {
		private readonly db_context _dbContext;
		private readonly IDistributedCache _cache;
		public UserManagerService(db_context dbContext, IDistributedCache cache)
		{
			_dbContext = dbContext;
			_cache = cache;
		}

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

		public Task<UserViewDTO> CreateAsync(UserCreateDTO dto)
        {
            throw new NotImplementedException();
        }

        public Task<UserViewDTO> UpdateAsync(UserUpdateDTO dto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<UserViewDTO?> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<UserViewDTO?> GetByUserNameAsync(string userName)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserViewDTO>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> FollowAsync(UserFollowDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}
