using class_library.DTO;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using web_api.Lib.Database;
using web_api.Lib.Services.Interfaces;

namespace web_api.Lib.Services
{
    public class SubjectManagerService : ISubjectManagerService
    {
		private readonly db_context _dbContext;
		private readonly IDistributedCache _cache;
		public SubjectManagerService(db_context dbContext, IDistributedCache cache)
		{
			_dbContext = dbContext;
			_cache = cache;
		}

		private async Task<IQueryable<Subject>> querrySubjects()
		{
			var cachedData = await _cache.GetStringAsync("subject");
			if (!string.IsNullOrEmpty(cachedData))
			{
				var data = JsonConvert.DeserializeObject<List<Subject>>(cachedData);
				return data.AsQueryable();
			}
			var dataFromDb = await _dbContext.Subjects.OrderBy(c => c.ID).ToListAsync();
			var cacheOptions = new DistributedCacheEntryOptions
			{
				AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10),
				SlidingExpiration = TimeSpan.FromMinutes(5)
			};

			var serializedData = JsonConvert.SerializeObject(dataFromDb);
			await _cache.SetStringAsync("subject", serializedData, cacheOptions);
			return dataFromDb.AsQueryable();
		}

		public async Task<SubjectViewDTO> CreateAsync(SubjectCreateDTO dto)
        {
			using var transaction = await _dbContext.Database.BeginTransactionAsync();
			try
			{
				var existingSubjects = await querrySubjects();
				if (existingSubjects.Any(p => p.Name == dto.Name && p.InstitutionID == dto.InstitutionID))
				{
					throw new Exception("Subject with the same name already exists in this institution");
				}
				var entity = new Subject
				{
					ID = Guid.NewGuid(),
					Name = dto.Name,
					InstitutionID = dto.InstitutionID,
					InstructorID = dto.InstructorID
				};
				_dbContext.Subjects.Add(entity);
				await _dbContext.SaveChangesAsync();
				await _cache.RemoveAsync("subject");
				await transaction.CommitAsync();
				return new SubjectViewDTO
				{
					ID = entity.ID,
					Name = entity.Name,
					InstitutionID = entity.InstitutionID,
					InstructorID = entity.InstructorID
				};
			}
			catch (Exception ex)
			{
				await transaction.RollbackAsync();
				throw new Exception("Failed to create subject", ex);
			}
			finally
			{
				await transaction.DisposeAsync();
			}
		}

        public async Task<SubjectViewDTO> UpdateAsync(SubjectViewDTO dto)
        {
            var existingSubjects = await querrySubjects();
			if ( existingSubjects == null) { 
				throw new Exception("No subjects found");
			}
			var entity = existingSubjects.FirstOrDefault(p => p.ID == dto.ID);
			if (entity == null)
			{
				throw new Exception("Subject not found");
			}
			using var transaction = await _dbContext.Database.BeginTransactionAsync();
			try
			{
				entity.Name = dto.Name;
				entity.InstitutionID = dto.InstitutionID;
				entity.InstructorID = dto.InstructorID;
				_dbContext.Subjects.Update(entity);
				await _dbContext.SaveChangesAsync();
				await _cache.RemoveAsync("subject");
				await transaction.CommitAsync();
				return dto;
			}
			catch (Exception ex)
			{
				await transaction.RollbackAsync();
				throw new Exception("Failed to update subject", ex);
			}
			finally
			{
				await transaction.DisposeAsync();
			}
		}

        public async Task<bool> DeleteAsync(Guid id)
        {
            var subjects = await querrySubjects();
			if (subjects == null)
			{
				throw new Exception("No subjects found");
			}
			var entity = subjects.FirstOrDefault(p => p.ID == id);
			if (entity == null)
			{
				throw new Exception("Subject not found");
			}
			using var transaction = await _dbContext.Database.BeginTransactionAsync();
			try
			{
				_dbContext.Subjects.Remove(entity);
				await _dbContext.SaveChangesAsync();
				await _cache.RemoveAsync("subject");
				await transaction.CommitAsync();
				return true;
			}
			catch (Exception ex)
			{
				await transaction.RollbackAsync();
				throw new Exception("Failed to delete subject", ex);
			}
			finally
			{
				await transaction.DisposeAsync();
			}
		}

        public async Task<SubjectViewDTO?> GetByIdAsync(Guid id)
        {
            var subjects = await querrySubjects();
			if (subjects == null)
			{
				throw new Exception("No subjects found");
			}
			var entity = subjects.FirstOrDefault(p => p.ID == id);
			if (entity == null)
			{
				throw new Exception("Subject not found");
			}
			return entity.Adapt<SubjectViewDTO>();
		}

        public async Task<IEnumerable<SubjectViewDTO>> GetAllAsync()
        {
            var subjects = await querrySubjects();
			if (subjects == null) {
				throw new Exception("No subjects found");
			}
			return subjects.Adapt<IEnumerable<SubjectViewDTO>>();
		}
    }
}
