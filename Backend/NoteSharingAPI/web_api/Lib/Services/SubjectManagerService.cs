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

		public async Task<object?> Search(SubjectSearchDTO dto)
		{
			var query = await querrySubjects();

			var general = dto.GeneralField?.Trim().ToLower();
			var name = dto.NameField?.Trim().ToLower();
			var code = dto.NeptunCodeField?.Trim().ToLower();

			// APPLY FILTERING
			if (!string.IsNullOrWhiteSpace(general))
			{
				query = query.Where(s =>
					s.Name.ToLower().Contains(general) ||
					s.NeptunCode.ToLower().Contains(general));
			}

			if (!string.IsNullOrWhiteSpace(name))
				query = query.Where(s => s.Name.ToLower().Contains(name));

			if (!string.IsNullOrWhiteSpace(code))
				query = query.Where(s => s.NeptunCode.ToLower().Contains(code));

			
				query = query
					.Select(s => new
					{
						Subject = s,
						Score =
							(!string.IsNullOrEmpty(general) && s.Name.ToLower() == general ? 100 : 0) +
							(!string.IsNullOrEmpty(general) && s.NeptunCode.ToLower() == general ? 100 : 0) +

							(!string.IsNullOrEmpty(name) && s.Name.ToLower() == name ? 80 : 0) +
							(!string.IsNullOrEmpty(code) && s.NeptunCode.ToLower() == code ? 80 : 0) +

							(!string.IsNullOrEmpty(general) && s.Name.ToLower().StartsWith(general) ? 40 : 0) +
							(!string.IsNullOrEmpty(general) && s.NeptunCode.ToLower().StartsWith(general) ? 40 : 0) +

							(!string.IsNullOrEmpty(name) && s.Name.ToLower().StartsWith(name) ? 20 : 0) +
							(!string.IsNullOrEmpty(code) && s.NeptunCode.ToLower().StartsWith(code) ? 20 : 0) +

							(!string.IsNullOrEmpty(general) && s.Name.ToLower().Contains(general) ? 10 : 0) +
							(!string.IsNullOrEmpty(general) && s.NeptunCode.ToLower().Contains(general) ? 10 : 0) +

							(!string.IsNullOrEmpty(name) && s.Name.ToLower().Contains(name) ? 5 : 0) +
							(!string.IsNullOrEmpty(code) && s.NeptunCode.ToLower().Contains(code) ? 5 : 0)
					})
					.OrderByDescending(x => x.Score)
					.ThenBy(x => x.Subject.Name)
					.Select(x => x.Subject);
			

			return query.Adapt<List<SubjectViewDTO>>();
		}
	}
}
