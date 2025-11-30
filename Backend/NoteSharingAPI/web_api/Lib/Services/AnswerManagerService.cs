using class_library.DTO;
using class_library.Enums;
using class_library.Models;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using web_api.Lib.Database;
using web_api.Lib.Services.Interfaces;

namespace web_api.Lib.Services
{
    public class AnswerManagerService : IAnswerManagerService
    {
		private readonly db_context _dbContext;
		private readonly IDistributedCache _cache;
		private readonly IServiceScopeFactory _scopeFactory;
		public AnswerManagerService(db_context dbContext, IDistributedCache cache, IServiceScopeFactory scopeFactory)
		{
			_dbContext = dbContext;
			_cache = cache;
			_scopeFactory = scopeFactory;
		}

		private async Task<IQueryable<NoteRequestAnswer>> querryAnswers()
		{
			var cachedData = await _cache.GetStringAsync("requestAnswers");
			if (!string.IsNullOrEmpty(cachedData))
			{
				var data = JsonConvert.DeserializeObject<List<NoteRequestAnswer>>(cachedData);
				return data.AsQueryable();
			}
			var dataFromDb = await _dbContext.NoteRequestAnswers.OrderBy(c => c.ID).ToListAsync();
			var cacheOptions = new DistributedCacheEntryOptions
			{
				AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10),
				SlidingExpiration = TimeSpan.FromMinutes(5)
			};

			var serializedData = JsonConvert.SerializeObject(dataFromDb);
			await _cache.SetStringAsync("requestAnswers", serializedData, cacheOptions);
			return dataFromDb.AsQueryable();
		}

		public async Task<bool> ChangeStatus(Guid answerId, EAnswerStatus status)
		{
			var answers = await querryAnswers();
			var answer = answers.FirstOrDefault(a => a.ID == answerId);
			if (answer == null)
			{
				throw new Exception("Answer not found");
			}
			answer.Status = status;
			var transaction = await _dbContext.Database.BeginTransactionAsync();
			try
			{
				_dbContext.NoteRequestAnswers.Update(answer);
				await _dbContext.SaveChangesAsync();
				await transaction.CommitAsync();
				// Invalidate cache
				await _cache.RemoveAsync("requestAnswers");
				await Log(message: "Answer for a NoteRequest status has changed");
				return true;
			}
			catch (Exception e)
			{
				await transaction.RollbackAsync();
				throw new Exception($"Failed to change answer status: {e.InnerException}");
			}
			finally
			{
				await transaction.DisposeAsync();
			}
		}

		public async Task<NoteRequestAnswerViewDTO> Create(NoteRequestAnswerCreateDTO dto)
		{
			var transaction = _dbContext.Database.BeginTransaction();
			try { 				
				var newAnswer = new NoteRequestAnswer()
				{
					UploaderUserID = dto.UploaderUserID,
					RequestID = dto.RequestID,
					Content = dto.Content,
					Description = dto.Description,
					CreatedAt = DateTime.UtcNow,
					Status = EAnswerStatus.Pending
				};
				_dbContext.NoteRequestAnswers.Add(newAnswer);
				_dbContext.SaveChanges();
				transaction.Commit();
				// Invalidate cache
				await _cache.RemoveAsync("requestAnswers");
				await Log(message: "New Answer for a NoteRequest has been created");
				var answerViewDTO = new NoteRequestAnswerViewDTO()
				{
					ID = newAnswer.ID,
					UploaderUserID = newAnswer.UploaderUserID,
					RequestID = newAnswer.RequestID,
					Content = newAnswer.Content,
					Description = newAnswer.Description,
					CreatedAt = newAnswer.CreatedAt,
					Status = newAnswer.Status
				};
				return answerViewDTO;
			}
			catch (Exception e)
			{
				transaction.Rollback();
				throw new Exception($"Failed to create noteRequestAnswer: {e.InnerException}");
			}
			finally
			{
				transaction.Dispose();
			}
		}

		public async Task<IEnumerable<NoteRequestAnswerViewDTO>> GetByNote(Guid noteId)
		{
			var answers = await querryAnswers();
			var filteredAnswers = answers.Where(a => a.RequestID == noteId);
			return filteredAnswers.Adapt<IEnumerable<NoteRequestAnswerViewDTO>>();
		}

		public async Task<IEnumerable<NoteRequestAnswerViewDTO>> GetByUser(Guid userId)
		{
			var answers = await querryAnswers();
			var filteredAnswers = answers.Where(a => a.UploaderUserID == userId);
			return filteredAnswers.Adapt<IEnumerable<NoteRequestAnswerViewDTO>>();
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
			if (response == null)
			{
				throw new Exception($"Couldn't log activity: '{message}'");
			}
		}


	}
}
