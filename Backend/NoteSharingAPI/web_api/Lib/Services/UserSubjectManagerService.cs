using class_library.DTO;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using web_api.Lib.Database;
using web_api.Lib.Services.Interfaces;

namespace web_api.Lib.Services
{
	public class UserSubjectManagerService : IUserSubjectManagerService
	{
		private readonly db_context _dbContext;
		private readonly IDistributedCache _cache;
		public UserSubjectManagerService(db_context dbContext, IDistributedCache cache)
		{
			_dbContext = dbContext;
			_cache = cache;
		}

		private async Task<IQueryable<UserSubject>> querryUserSubjects()
		{
			var cachedData = await _cache.GetStringAsync("usersubject");
			if (!string.IsNullOrEmpty(cachedData))
			{
				var data = JsonConvert.DeserializeObject<List<UserSubject>>(cachedData);
				return data.AsQueryable();
			}
			var dataFromDb = await _dbContext.UserSubjects.OrderBy(c => c.UserID).ToListAsync();
			var cacheOptions = new DistributedCacheEntryOptions
			{
				AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10),
				SlidingExpiration = TimeSpan.FromMinutes(5)
			};

			var serializedData = JsonConvert.SerializeObject(dataFromDb);
			await _cache.SetStringAsync("usersubjects", serializedData, cacheOptions);
			return dataFromDb.AsQueryable();
		}

		public async Task<bool> AddAsync(UserSubjectDTO dto)
		{
			var usersubjects = await querryUserSubjects();
			if (usersubjects != null && usersubjects.Any(us => us.UserID == dto.UserID && us.SubjectID == dto.SubjectID))
			{
				throw new Exception("This subject is already assigned to the user");
			}
			using var dbTransaction = await _dbContext.Database.BeginTransactionAsync();
			try
			{
				var entity = new UserSubject
				{
					UserID = dto.UserID,
					SubjectID = dto.SubjectID
				};
				_dbContext.UserSubjects.Add(entity);
				await _dbContext.SaveChangesAsync();
				await _cache.RemoveAsync("usersubject");
				await dbTransaction.CommitAsync();
				return true;
			}
			catch
			{
				await dbTransaction.RollbackAsync();
				throw new Exception("Failed to add subject to user");
			}
			finally
			{
				await dbTransaction.DisposeAsync();
			}
		}

		public async Task<IEnumerable<SubjectViewDTO>> GetByUserAsync(Guid userId)
		{
			var usersubjects = await querryUserSubjects();
			if (usersubjects == null)
			{
				throw new Exception("No user subjects found");
			}
			var userSubjectsForUser = usersubjects.Where(us => us.UserID == userId);
			if (!userSubjectsForUser.Any())
			{
				throw new Exception("No subjects found for this user");
			}
			var subjectList = new List<SubjectViewDTO>();
			foreach (var us in userSubjectsForUser)
			{
				var subject = await _dbContext.Subjects.FindAsync(us.SubjectID);
				if(subject != null)
				{
					subjectList.Add(subject.Adapt<SubjectViewDTO>());
				}
			}
			return subjectList.AsEnumerable<SubjectViewDTO>();
		}

		public async Task<bool> RemoveAsync(UserSubjectDTO dto)
		{
			var usersubjects = await querryUserSubjects();
			if (usersubjects == null || !usersubjects.Any(us => us.UserID == dto.UserID && us.SubjectID == dto.SubjectID))
			{
				throw new Exception("This subject is not assigned to the user");
			}
			using var dbTransaction = await _dbContext.Database.BeginTransactionAsync();
			try
			{
				var entity = usersubjects.First(us => us.UserID == dto.UserID && us.SubjectID == dto.SubjectID);
				_dbContext.UserSubjects.Remove(entity);
				await _dbContext.SaveChangesAsync();
				await _cache.RemoveAsync("usersubject");
				await dbTransaction.CommitAsync();
				return true;
			}
			catch
			{
				await dbTransaction.RollbackAsync();
				throw new Exception("Failed to remove subject from user");
			}
			finally
			{
				await dbTransaction.DisposeAsync();
			}
	}
}
