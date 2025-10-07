using class_library.DTO;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using web_api.Lib.Database;
using web_api.Lib.Services.Interfaces;

namespace web_api.Lib.Services
{
    public class InstitutionManagerService : IInstitutionManagerService
    {
		private readonly db_context _dbContext;
		private readonly IDistributedCache _cache;
		public InstitutionManagerService(db_context dbContext, IDistributedCache cache)
		{
			_dbContext = dbContext;
			_cache = cache;
		}
		private async Task<IQueryable<Institution>> querryInstitutions()
		{
			var cachedData = await _cache.GetStringAsync("institutions");
			if (!string.IsNullOrEmpty(cachedData))
			{
				var data = JsonConvert.DeserializeObject<List<Institution>>(cachedData);
				return data.AsQueryable();
			}
			var dataFromDb = await _dbContext.Institutions.OrderBy(c => c.ID).ToListAsync();
			var cacheOptions = new DistributedCacheEntryOptions
			{
				AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10),
				SlidingExpiration = TimeSpan.FromMinutes(5)
			};

			var serializedData = JsonConvert.SerializeObject(dataFromDb);
			await _cache.SetStringAsync("institutions", serializedData, cacheOptions);
			return dataFromDb.AsQueryable();
		}

		public Task<InstitutionViewDTO> CreateAsync(InstitutionCreateDTO dto)
        {
            throw new NotImplementedException();
        }

        public Task<InstitutionViewDTO> UpdateAsync(InstitutionViewDTO dto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<InstitutionViewDTO?> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<InstitutionViewDTO>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
