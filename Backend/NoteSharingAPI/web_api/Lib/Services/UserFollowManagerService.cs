using class_library.DTO;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using web_api.Lib.Database;
using web_api.Lib.Services.Interfaces;

namespace web_api.Lib.Services
{
    public class UserFollowManagerService : IUserFollowManagerService
    {
		private readonly db_context _dbContext;
		private readonly IDistributedCache _cache;
		public UserFollowManagerService(db_context dbContext, IDistributedCache cache)
		{
			_dbContext = dbContext;
			_cache = cache;
		}

		private async Task<IQueryable<UserFollow>> querryUserFollows()
		{
			var cachedData = await _cache.GetStringAsync("userfollow");
			if (!string.IsNullOrEmpty(cachedData))
			{
				var data = JsonConvert.DeserializeObject<List<UserFollow>>(cachedData);
				return data.AsQueryable();
			}
			var dataFromDb = await _dbContext.UserFollows.OrderBy(c => c.FollowerUserID).ToListAsync();
			var cacheOptions = new DistributedCacheEntryOptions
			{
				AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10),
				SlidingExpiration = TimeSpan.FromMinutes(5)
			};

			var serializedData = JsonConvert.SerializeObject(dataFromDb);
			await _cache.SetStringAsync("userfollow", serializedData, cacheOptions);
			return dataFromDb.AsQueryable();
		}

		public async Task<bool> FollowAsync(UserFollowDTO dto)
        {
			var userfollows = await querryUserFollows();
			if (userfollows != null && userfollows.Any(uf => uf.FollowerUserID == dto.FollowerUserID && uf.FollowedUserID == dto.FollowedUserID))
			{
				throw new Exception("You are already following this user");
			}
			using var dbTransaction = await _dbContext.Database.BeginTransactionAsync();
			try
			{
				var entity = new UserFollow
				{
					FollowerUserID = dto.FollowerUserID,
					FollowedUserID = dto.FollowedUserID
				};
				_dbContext.UserFollows.Add(entity);
				await _dbContext.SaveChangesAsync();
				await _cache.RemoveAsync("userfollow");
				await dbTransaction.CommitAsync();
				return true;
			}
			catch
			{
				await dbTransaction.RollbackAsync();
				throw;
			}
		}

        public async Task<bool> UnfollowAsync(UserFollowDTO dto)
        {
            var userfollows = await querryUserFollows();
			if (!userfollows.Any(uf => uf.FollowerUserID == dto.FollowerUserID && uf.FollowedUserID == dto.FollowedUserID))
			{
				throw new Exception("You are not following this user");
			}
			var entity = userfollows.FirstOrDefault(uf => uf.FollowerUserID == dto.FollowerUserID && uf.FollowedUserID == dto.FollowedUserID);
			if (entity == null)
			{
				throw new Exception("You are not following this user");
			}
			var dbTransaction = await _dbContext.Database.BeginTransactionAsync();
			try
			{
				_dbContext.UserFollows.Remove(entity);
				await _dbContext.SaveChangesAsync();
				await _cache.RemoveAsync("userfollow");
				await dbTransaction.CommitAsync();
				return true;
			}
			catch
			{
				await dbTransaction.RollbackAsync();
				throw;
			}
			finally
			{
				await dbTransaction.DisposeAsync();
			}
		}

        public async Task<FollowerReportDTO> GetFollowersAsync(Guid userId)
        {
            var userfollows = await querryUserFollows();
			if (userfollows == null)
			{
				throw new Exception("No followers in database");
			}
			List<string> usernames = userfollows.Where(uf => uf.FollowedUserID == userId).Select(uf => uf.FollowerUser.UserName).ToList();
			if (usernames.Count == 0)
			{
				throw new Exception("No followers found");
			}
			return new FollowerReportDTO
			{
				UserNames = usernames,
				AccountCount = usernames.Count

			};
		}

        public async Task<FollowerReportDTO> GetFollowingAsync(Guid userId)
        {
			var userfollows = await querryUserFollows();
			if (userfollows == null)
			{
				throw new Exception("No followings in database");
			}
			foreach (var uf in userfollows)
			{
				uf.FollowedUser = await _dbContext.Users.FirstOrDefaultAsync(u => u.ID == uf.FollowedUserID);
			}
			List<string> usernames = userfollows.Where(uf => uf.FollowerUserID == userId).Select(uf => uf.FollowedUser.UserName).ToList();
			if (usernames.Count == 0)
			{
				throw new Exception("No followers found");
			}
			return new FollowerReportDTO
			{
				UserNames = usernames,
				AccountCount = usernames.Count
			};
		}
    }
}
