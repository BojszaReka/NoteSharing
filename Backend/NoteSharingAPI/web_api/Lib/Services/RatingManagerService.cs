using class_library.DTO;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using web_api.Lib.Database;
using web_api.Lib.Services.Interfaces;

namespace web_api.Lib.Services
{
    public class RatingsManagerService : IRatingsManagerService
    {
		private readonly db_context _dbContext;
		private readonly IDistributedCache _cache;
		private readonly IServiceScopeFactory _scopeFactory;
		public RatingsManagerService(db_context dbContext, IDistributedCache cache, IServiceScopeFactory scopeFactory)
		{
			_dbContext = dbContext;
			_cache = cache;
			_scopeFactory = scopeFactory;
		}

		private async Task<IQueryable<NoteRating>> querryRatings()
		{
			var cachedData = await _cache.GetStringAsync("ratings");
			if (!string.IsNullOrEmpty(cachedData))
			{
				var data = JsonConvert.DeserializeObject<List<NoteRating>>(cachedData);
				return data.AsQueryable();
			}
			var dataFromDb = await _dbContext.NoteRatings.OrderBy(c => c.ID).ToListAsync();
			var cacheOptions = new DistributedCacheEntryOptions
			{
				AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10),
				SlidingExpiration = TimeSpan.FromMinutes(5)
			};

			var serializedData = JsonConvert.SerializeObject(dataFromDb);
			await _cache.SetStringAsync("ratings", serializedData, cacheOptions);
			return dataFromDb.AsQueryable();
		}

		public Task<NoteRatingViewDTO> Add(NoteRatingCreateDTO dto) => throw new NotImplementedException();
        public Task<IEnumerable<NoteRatingViewDTO>> GetByNote(Guid noteId) => throw new NotImplementedException();
        public Task<bool> Delete(Guid ratingId) => throw new NotImplementedException();
    }
}
