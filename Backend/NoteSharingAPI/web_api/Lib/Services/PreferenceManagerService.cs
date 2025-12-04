using class_library.DTO;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using web_api.Lib.Database;
using web_api.Lib.Services.Interfaces;

namespace web_api.Lib.Services
{
    public class PreferenceManagerService : IPreferenceManagerService
    {
		private readonly db_context _dbContext;
		private readonly IDistributedCache _cache;
		public PreferenceManagerService(db_context dbContext, IDistributedCache cache)
		{
			_dbContext = dbContext;
			_cache = cache;
		}

		private async Task<IQueryable<Preference>> querryPreferences()
		{
			var cachedData = await _cache.GetStringAsync("preference");
			if (!string.IsNullOrEmpty(cachedData))
			{
				var data = JsonConvert.DeserializeObject<List<Preference>>(cachedData);
				return data.AsQueryable();
			}
			var dataFromDb = await _dbContext.Preferences.OrderBy(c => c.ID).ToListAsync();
			var cacheOptions = new DistributedCacheEntryOptions
			{
				AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10),
				SlidingExpiration = TimeSpan.FromMinutes(5)
			};

			var serializedData = JsonConvert.SerializeObject(dataFromDb);
			await _cache.SetStringAsync("preference", serializedData, cacheOptions);
			return dataFromDb.AsQueryable();
		}

		public async Task<PreferenceViewDTO> CreateAsync(PreferenceViewDTO dto)
        {
			var existingPreferences = await querryPreferences();
			if (existingPreferences.Any(p => p.ID == dto.ID))
			{
				throw new Exception("Preference with the same ID already exists");
			}
			using var transaction = _dbContext.Database.BeginTransaction();
			try
			{
				dto.ID = Guid.NewGuid();
				var entity = new Preference
				{
					ID = dto.ID,
					PrioritiseUsersFromInstitution = dto.PrioritiseUsersFromInstitution,
					PrioritiseInstructorNotes = dto.PrioritiseInstructorNotes,
					PrivateMyNotes = dto.PrivateMyNotes,
					PrioritiseRatedNotes = dto.PrioritiseRatedNotes,
					PrioritiseFollowedUsers = dto.PrioritiseFollowedUsers
				};
				_dbContext.Preferences.Add(entity);
				_dbContext.SaveChanges();
				await _cache.RemoveAsync("preference");
				transaction.Commit();
				return dto;
			}
			catch (Exception ex)
			{
				transaction.Rollback();
				throw new Exception("Failed to create preference", ex);
			}
			finally
			{
				transaction.Dispose();
			}
		}

        public async Task<PreferenceViewDTO> UpdateAsync(PreferenceViewDTO dto)
        {
            var existingPreferences = await querryPreferences();
			if (existingPreferences != null) { 
				throw new Exception("No preferences found");
			}
			var entity = existingPreferences.FirstOrDefault(p => p.ID == dto.ID);
			if (entity == null)
			{
				throw new Exception("Preference not found");
			}
			using var transaction = _dbContext.Database.BeginTransaction();
			try
			{
				entity.PrioritiseUsersFromInstitution = dto.PrioritiseUsersFromInstitution;
				entity.PrioritiseInstructorNotes = dto.PrioritiseInstructorNotes;
				entity.PrivateMyNotes = dto.PrivateMyNotes;
				entity.PrioritiseRatedNotes = dto.PrioritiseRatedNotes;
				entity.PrioritiseFollowedUsers = dto.PrioritiseFollowedUsers;
				_dbContext.Preferences.Update(entity);
				_dbContext.SaveChanges();
				await _cache.RemoveAsync("preference");
				transaction.Commit();
				return dto;
			}
			catch (Exception ex)
			{
				transaction.Rollback();
				throw new Exception("Failed to update preference", ex);
			}
			finally
			{
				transaction.Dispose();
			}
		}

        public async Task<bool> DeleteAsync(Guid id)
        {
            var existingPreferences = await querryPreferences();
			if (existingPreferences == null)
			{
				throw new Exception("No preferences found");
			}
			var preference = existingPreferences.FirstOrDefault(p => p.ID == id);
			if (preference == null)
			{
				throw new Exception("Preference not found");
			}
			using var transaction = _dbContext.Database.BeginTransaction();
			try
			{
				_dbContext.Preferences.Remove(preference);
				_dbContext.SaveChanges();
				await _cache.RemoveAsync("preference");
				transaction.Commit();
				return true;
			}
			catch (Exception ex)
			{
				transaction.Rollback();
				throw new Exception("Failed to delete preference", ex);
			}
			finally
			{
				transaction.Dispose();
			}
		}

        public async Task<PreferenceViewDTO?> GetByIdAsync(Guid id)
        {
            var preference = await querryPreferences();
			if (preference == null)
			{
				throw new Exception("No preferences found");
			}
			var entity = preference.FirstOrDefault(p => p.ID == id);
			if (entity == null)
			{
				throw new Exception("Preference not found");
			}
			return entity.Adapt<PreferenceViewDTO>();

		}

		public async Task<Preference> GetPreference(Guid preferenceID)
		{
			var preferences = await querryPreferences();
			return preferences.FirstOrDefault(p => p.ID == preferenceID) ?? throw new Exception("Preference not found");
		}
	}
}
