using class_library.DTO;
using class_library.Models;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using web_api.Lib.Database;
using web_api.Lib.Services.Interfaces;

namespace web_api.Lib.Services
{
    public class NoteManagerService : INoteManagerService
    {
		private readonly db_context _dbContext;
		private readonly IDistributedCache _cache;
		private readonly IServiceScopeFactory _scopeFactory;
		public NoteManagerService(db_context dbContext, IDistributedCache cache, IServiceScopeFactory scopeFactory)
		{
			_dbContext = dbContext;
			_cache = cache;
			_scopeFactory = scopeFactory;
		}

		private async Task<IQueryable<Note>> querryNotes()
		{
			var cachedData = await _cache.GetStringAsync("notes");
			if (!string.IsNullOrEmpty(cachedData))
			{
				var data = JsonConvert.DeserializeObject<List<Note>>(cachedData);
				return data.AsQueryable();
			}
			var dataFromDb = await _dbContext.Notes.OrderBy(c => c.ID).ToListAsync();
			var cacheOptions = new DistributedCacheEntryOptions
			{
				AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10),
				SlidingExpiration = TimeSpan.FromMinutes(5)
			};

			var serializedData = JsonConvert.SerializeObject(dataFromDb);
			await _cache.SetStringAsync("notes", serializedData, cacheOptions);
			return dataFromDb.AsQueryable();
		}

		public async Task<object?> AddReview(NoteRatingCreateDTO dto)
		{
			var scope = _scopeFactory.CreateScope();
			var noteRatingService = scope.ServiceProvider.GetRequiredService<INoteManagerService>();
			return await noteRatingService.AddReview(dto);
		}

		public async Task<NoteViewDTO> Create(NoteCreateDTO dto)
		{
			var transaction = await _dbContext.Database.BeginTransactionAsync();
			try
			{
				var note = dto.Adapt<Note>();
				note.ID = Guid.NewGuid();
				note.CreatedAt = DateTime.UtcNow;
				note.UpdatedAt = DateTime.UtcNow;
				note.IsDeleted = false;
				_dbContext.Notes.Add(note);
				await _dbContext.SaveChangesAsync();
				await transaction.CommitAsync();
				// Invalidate cache
				await _cache.RemoveAsync("notes");
				return note.Adapt<NoteViewDTO>();
			}
			catch (Exception e)
			{
				await transaction.RollbackAsync();
				throw new Exception("Error creating note", e.InnerException);
			}
			finally
			{
				await transaction.DisposeAsync();
			}
		}

		public async Task<bool> DeleteRating(Guid ratingId)
		{
			var scope = _scopeFactory.CreateScope();
			var noteRatingService = scope.ServiceProvider.GetRequiredService<INoteManagerService>();
			return await noteRatingService.DeleteRating(ratingId);
		}

		public async Task<object?> Dislike(NoteLikeDTO dto)
		{
			var scope = _scopeFactory.CreateScope();
			var noteRatingService = scope.ServiceProvider.GetRequiredService<INoteManagerService>();
			return await noteRatingService.Dislike(dto);
		}

		public async Task<ICollection<NoteViewDTO>> GetAll()
		{
			var notes = await querryNotes();
			var undeletedNotes =  notes.Where(n => !n.IsDeleted).Adapt<ICollection<NoteViewDTO>>();
			if(undeletedNotes == null)
			{
				throw new Exception("No notes found");
			}
			return undeletedNotes;
		}

		public async Task<IEnumerable<NoteViewDTO>> GetByAuthor(Guid userId)
		{
			var notes = await querryNotes();
			var authorNotes = notes.Where(n => n.AuthorUserID == userId && !n.IsDeleted).Adapt<IEnumerable<NoteViewDTO>>();
			if (authorNotes == null || !authorNotes.Any())
			{
				throw new Exception("No notes found for this author");
			}
			return authorNotes;

		}

		public async Task<NoteViewDTO> Get(Guid id)
		{
			var notes = await querryNotes();
			var note = notes.FirstOrDefault(n => n.ID == id && !n.IsDeleted);
			if (note == null)
			{
				throw new Exception("Note not found");
			}
			return note.Adapt<NoteViewDTO>();
		}

		public async Task<IEnumerable<NoteViewDTO>> GetBySubject(Guid subjectId)
		{
			var notes = await querryNotes();
			var subjectNotes = notes.Where(n => n.SubjectID == subjectId && !n.IsDeleted).Adapt<IEnumerable<NoteViewDTO>>();
			if (subjectNotes == null || !subjectNotes.Any())
			{
				throw new Exception("No notes found for this subject");
			}
			return subjectNotes;
		}

		public async Task<IEnumerable<NoteRatingViewDTO>> GetRatings(Guid noteId)
		{
			var scope = _scopeFactory.CreateScope();
			var noteRatingService = scope.ServiceProvider.GetRequiredService<INoteManagerService>();
			return await noteRatingService.GetRatings(noteId);
		}

		public async Task<object?> Like(NoteLikeDTO dto)
		{
			var scope = _scopeFactory.CreateScope();
			var noteRatingService = scope.ServiceProvider.GetRequiredService<INoteManagerService>();
			return await noteRatingService.Like(dto);
		}

		public async Task<NoteRatingViewDTO> Rate(NoteRatingCreateDTO dto)
		{
			var scope = _scopeFactory.CreateScope();
			var noteRatingService = scope.ServiceProvider.GetRequiredService<INoteManagerService>();
			return await noteRatingService.Rate(dto);
		}

		public Task<IEnumerable<NoteViewDTO>> Search(Guid? institutionId, Guid? subjectId, string? text)
		{
			throw new NotImplementedException();
		}

		public async Task<bool> Delete(Guid id)
		{
			var transaction = await _dbContext.Database.BeginTransactionAsync();
			try
			{
				var notes = await querryNotes();
				var note = notes.FirstOrDefault(n => n.ID == id && !n.IsDeleted);
				if (note == null)
				{
					throw new Exception("Note not found");
				}
				note.IsDeleted = true;
				_dbContext.Notes.Update(note);
				await _dbContext.SaveChangesAsync();
				await transaction.CommitAsync();
				// Invalidate cache
				await _cache.RemoveAsync("notes");
				return true;
			}
			catch (Exception e)
			{
				await transaction.RollbackAsync();
				throw new Exception("Error deleting note", e.InnerException);
			}
			finally
			{
				await transaction.DisposeAsync();
			}
		}

		public async Task<bool> Update(NoteUpdateDTO dto)
		{
			var transaction = await _dbContext.Database.BeginTransactionAsync();
			try
			{
				var notes = await querryNotes();
				var note = notes.FirstOrDefault(n => n.ID == dto.ID && !n.IsDeleted);
				if (note == null)
				{
					throw new Exception("Note not found");
				}
				note.Title = dto.Title;
				note.Description = dto.Description;
				note.Content = dto.Content;
				note.SubjectID = dto.SubjectID;
				note.InstitutionID = dto.InstitutionID;
				note.UpdatedAt = DateTime.UtcNow;
				_dbContext.Notes.Update(note);
				await _dbContext.SaveChangesAsync();
				await transaction.CommitAsync();
				// Invalidate cache
				await _cache.RemoveAsync("notes");
				return true;
			}
			catch (Exception e)
			{
				await transaction.RollbackAsync();
				throw new Exception("Error updating note", e.InnerException);
			}
			finally
			{
				await transaction.DisposeAsync();
			}
		}		
	}
}
