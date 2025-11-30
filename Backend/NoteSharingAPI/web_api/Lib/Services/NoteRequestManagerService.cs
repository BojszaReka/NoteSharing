using class_library.DTO;
using class_library.Enums;
using class_library.Models;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web_api.Lib.Database;
using web_api.Lib.Services.Interfaces;

namespace web_api.Lib.Services
{
	public class NoteRequestManagerService : INoteRequestManagerService
	{
		private readonly db_context _dbContext;
		private readonly IDistributedCache _cache;
		private readonly IServiceScopeFactory _scopeFactory;
		public NoteRequestManagerService(db_context dbContext, IDistributedCache cache, IServiceScopeFactory scopeFactory)
		{
			_dbContext = dbContext;
			_cache = cache;
			_scopeFactory = scopeFactory;
		}

		private async Task<IQueryable<NoteRequest>> querryNoteRequests()
		{
			var cachedData = await _cache.GetStringAsync("noteRequests");
			if (!string.IsNullOrEmpty(cachedData))
			{
				var data = JsonConvert.DeserializeObject<List<NoteRequest>>(cachedData);
				return data.AsQueryable();
			}
			var dataFromDb = await _dbContext.NoteRequests.OrderBy(c => c.ID).ToListAsync();
			var cacheOptions = new DistributedCacheEntryOptions
			{
				AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10),
				SlidingExpiration = TimeSpan.FromMinutes(5)
			};

			var serializedData = JsonConvert.SerializeObject(dataFromDb);
			await _cache.SetStringAsync("noteRequests", serializedData, cacheOptions);
			return dataFromDb.AsQueryable();
		}

		public async Task<NoteRequestAnswerViewDTO> AddAnswerAsync(NoteRequestAnswerCreateDTO dto)
		{
			var scope = _scopeFactory.CreateScope();
			var service = scope.ServiceProvider.GetRequiredService<IAnswerManagerService>();
			return await service.Create(dto);
		}

		public async Task<bool> ChangeAnswerStatusAsync(Guid answerId, EAnswerStatus status)
		{
			var scope = _scopeFactory.CreateScope();
			var service = scope.ServiceProvider.GetRequiredService<IAnswerManagerService>();
			return await service.ChangeStatus(answerId, status);
		}

		public async Task<bool> ChangeRequestStatusAsync(Guid requestId, ERequestStatus status)
		{
			var noteRequests = await querryNoteRequests();
			var request = noteRequests.FirstOrDefault(nr => nr.ID == requestId);
			if (request == null)
			{
				return false;
			}
			var transition = _dbContext.Database.BeginTransaction();
			try
			{
				request.Status = status;
				_dbContext.NoteRequests.Update(request);
				await _dbContext.SaveChangesAsync();
				await transition.CommitAsync();
				// Invalidate cache
				await _cache.RemoveAsync("noteRequests");
				return true;
			}
			catch (Exception e)
			{
				await transition.RollbackAsync();
				throw new Exception($"Failed to change request status: {e.Message}");
			}
			finally { 
				await transition.DisposeAsync();
			}
		}

		public async Task<NoteRequestViewDTO> CreateAsync(NoteRequestCreateDTO dto)
		{
			var transition = _dbContext.Database.BeginTransaction();
			try
			{
				var noteRequest = dto.Adapt<NoteRequest>();
				noteRequest.Status = ERequestStatus.Requested;
				noteRequest.CreatedAt = DateTime.UtcNow;
				_dbContext.NoteRequests.Add(noteRequest);
				await _dbContext.SaveChangesAsync();
				await transition.CommitAsync();
				// Invalidate cache
				await _cache.RemoveAsync("noteRequests");
				return noteRequest.Adapt<NoteRequestViewDTO>();
			}
			catch (Exception e)
			{
				await transition.RollbackAsync();
				throw new Exception($"Failed to create note request: {e.Message}");
			}
			finally
			{
				await transition.DisposeAsync();
			}
		}

		public async Task<NoteRequestViewDTO> Get(Guid noteId)
		{
			var requests = await querryNoteRequests();
			var request = requests.FirstOrDefault(nr => nr.ID == noteId);
			if (request == null)
			{
				throw new Exception("Note request not found");
			}
			return request.Adapt<NoteRequestViewDTO>();
		}

		public async Task<IEnumerable<NoteRequestViewDTO>> GetByCreator(Guid userId)
		{
			var noteRequests = await querryNoteRequests();
			var requests = noteRequests.Where(nr => nr.CreatorUserID == userId).Adapt<IEnumerable<NoteRequestViewDTO>>();
			if(requests == null || !requests.Any())
			{
				throw new Exception("No note requests found for this user");
			}
			return requests;
		}

		public async Task<IEnumerable<NoteRequestViewDTO>> GetByUserAsync(Guid userId)
		{
			IEnumerable<NoteRequestViewDTO> notes = await GetByCreator(userId);
			return notes;
		}

		public async Task<IEnumerable<NoteRequestViewDTO>> GetRelevantRequestAsync(Guid userId)
		{
			var requests = await querryNoteRequests();
			var relevantRequests = requests
				.Where(nr => nr.Status == ERequestStatus.Requested)
				.Adapt<IEnumerable<NoteRequestViewDTO>>();
			if(relevantRequests == null || !relevantRequests.Any())
			{
				throw new Exception("No relevant note requests found");
			}	
			return relevantRequests;
		}

		public async Task<object?> GetRelevantRequestByUser(Guid userId)
		{
			return await GetRelevantRequestAsync(userId);
		}

		public async Task<NoteRequestViewDTO> ModifyAsync(NoteRequestModifyDTO dto)
		{
			var transition = _dbContext.Database.BeginTransaction();
			try
			{
				var existingRequest = await _dbContext.NoteRequests.FirstOrDefaultAsync(nr => nr.ID == dto.ID);
				if (existingRequest == null)
				{
					throw new Exception("Note request not found");
				}
				existingRequest.Topic = dto.Topic;
				existingRequest.Description = dto.Description;
				existingRequest.Status = dto.Status;
				existingRequest.SubjectID = dto.SubjectID;

				_dbContext.NoteRequests.Update(existingRequest);
				await _dbContext.SaveChangesAsync();
				await transition.CommitAsync();
				// Invalidate cache
				await _cache.RemoveAsync("noteRequests");
				return existingRequest.Adapt<NoteRequestViewDTO>();
			}
			catch (Exception e)
			{
				await transition.RollbackAsync();
				throw new Exception($"Failed to modify note request: {e.Message}");
			}
			finally
			{
				await transition.DisposeAsync();
			}
		}

		public async Task<object?> ModifyRequest(NoteRequestModifyDTO dto)
		{
			return await ModifyAsync(dto);
		}

		public async Task<bool> UpdateAnswerStatus(Guid answerId, EAnswerStatus newStatus)
		{
			var scope = _scopeFactory.CreateScope();
			var service = scope.ServiceProvider.GetRequiredService<IAnswerManagerService>();
			return await service.ChangeStatus(answerId, newStatus);
		}

		public async Task<object?> UpdateStatus(Guid requestId, ERequestStatus newStatus)
		{
			var transition = _dbContext.Database.BeginTransaction();
			try
			{
				var existingRequest = await _dbContext.NoteRequests.FirstOrDefaultAsync(nr => nr.ID == requestId);
				if (existingRequest == null)
				{
					throw new Exception("Note request not found");
				}
				existingRequest.Status = newStatus;
				_dbContext.NoteRequests.Update(existingRequest);
				await _dbContext.SaveChangesAsync();
				await transition.CommitAsync();
				// Invalidate cache
				await _cache.RemoveAsync("noteRequests");
				return true;
			}
			catch (Exception e)
			{
				await transition.RollbackAsync();
				throw new Exception($"Failed to update note request status: {e.Message}");
			}
			finally
			{
				await transition.DisposeAsync();
			}
		}

		public async Task<IEnumerable<NoteRequestAnswerViewDTO>> ViewAnswersByNoteAsync(Guid noteId)
		{
			var scope = _scopeFactory.CreateScope();
			var service = scope.ServiceProvider.GetRequiredService<IAnswerManagerService>();
			return await service.GetByNote(noteId);
		}

		public async Task<IEnumerable<NoteRequestAnswerViewDTO>> ViewAnswersByUserAsync(Guid userId)
		{
			var scope = _scopeFactory.CreateScope();
			var service = scope.ServiceProvider.GetRequiredService<IAnswerManagerService>();
			return await service.GetByUser(userId);
		}
	}
}
