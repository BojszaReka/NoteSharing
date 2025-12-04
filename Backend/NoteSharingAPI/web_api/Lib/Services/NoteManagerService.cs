using class_library.DTO;
using class_library.Models;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using web_api.Lib.Database;
using web_api.Lib.Services.Interfaces;
using web_api.Lib.UnitOfWork;

namespace web_api.Lib.Services
{
    public class NoteManagerService : INoteManagerService
    {
		private readonly db_context _dbContext;
		private readonly IDistributedCache _cache;
		private readonly IUnitOfWork _unitOfWork;
		private readonly IServiceScopeFactory _scopeFactory;

		public NoteManagerService(db_context dbContext, IDistributedCache cache, IServiceScopeFactory scopeFactory, IUnitOfWork unitOfWork)
		{
			_dbContext = dbContext;
			_cache = cache;
			_unitOfWork = unitOfWork;
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

		private async Task<IQueryable<NoteHistory>> querryNoteHistories()
		{
			var cachedData = await _cache.GetStringAsync("history");
			if (!string.IsNullOrEmpty(cachedData))
			{
				var data = JsonConvert.DeserializeObject<List<NoteHistory>>(cachedData);
				return data.AsQueryable();
			}
			var dataFromDb = await _dbContext.NoteHistories.OrderBy(c => c.ID).ToListAsync();
			var cacheOptions = new DistributedCacheEntryOptions
			{
				AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10),
				SlidingExpiration = TimeSpan.FromMinutes(5)
			};

			var serializedData = JsonConvert.SerializeObject(dataFromDb);
			await _cache.SetStringAsync("history", serializedData, cacheOptions);
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

		public async Task<object?> Search(NoteSearchDTO dto)
		{
			IEnumerable<Note> notes = await querryNotes();

			// Fetch user preferences
			UserViewDTO? user = await _unitOfWork.userRepository.GetById(dto.RequestingUserID);
			Preference preferences = await _unitOfWork.preferenceRepository.GetByUserId(dto.RequestingUserID);
			FollowerReportDTO followedUsers = await _unitOfWork.userFollowRepository.GetFollowing(dto.RequestingUserID);
			var institutionID = user.InstitutionID;

			// BASE FILTER
			var query = notes.Where(n => !n.IsDeleted);

			// PRIVACY RULE
			if (preferences.PrivateMyNotes)
				query = query.Where(n => n.AuthorUserID == dto.RequestingUserID);

			// FIELD FILTERS
			if (dto.SubjectID.HasValue)
				query = query.Where(n => n.SubjectID == dto.SubjectID);

			if (dto.InstitutionID.HasValue)
				query = query.Where(n => n.InstitutionID == dto.InstitutionID);

			if (dto.AuthorUserID.HasValue)
				query = query.Where(n => n.AuthorUserID == dto.AuthorUserID);

			// FIELD-SPECIFIC SEARCH
			if (!string.IsNullOrWhiteSpace(dto.Title))
				query = query.Where(n => n.Title.Contains(dto.Title));

			if (!string.IsNullOrWhiteSpace(dto.Description))
				query = query.Where(n => n.Description.Contains(dto.Description));

			if (!string.IsNullOrWhiteSpace(dto.Content))
				query = query.Where(n => n.Content.Contains(dto.Content));

			// UNIVERSAL SEARCH
			if (!string.IsNullOrWhiteSpace(dto.Query))
			{
				var q = dto.Query.ToLower();

				query = query.Where(n =>
					n.Title.ToLower().Contains(q) ||
					n.Description.ToLower().Contains(q) ||
					n.Content.ToLower().Contains(q)
				);
			}

			// PROJECTION WITH SCORING
			var ranked = query
				.Select(n => new
				{
					Note = n,
					AvgRating = n.Ratings.Any() ? n.Ratings.Average(r => r.Stars) : 0,

					RelevanceScore =
						(dto.Query != null && n.Title.Contains(dto.Query) ? 6 : 0) +
						(dto.Query != null && n.Description.Contains(dto.Query) ? 3 : 0) +
						(dto.Query != null && n.Content.Contains(dto.Query) ? 1 : 0),

					PreferenceScore =
						(preferences.PrioritiseUsersFromInstitution && n.InstitutionID == institutionID ? 3 : 0) +
						(preferences.PrioritiseFollowedUsers && followedUsers.UserNames != null && n.Author != null && followedUsers.UserNames.Contains(n.Author.UserName) ? 4 : 0) +
						(preferences.PrioritiseInstructorNotes && n.Author.UserType == EUserType.Instructor ? 3 : 0) +
						(preferences.PrioritiseRatedNotes && n.Ratings.Any() ? 2 : 0)
				});

			// ORDERING LOGIC
			ranked = ranked
				.OrderByDescending(x =>
					(dto.OrderByRelevance ? x.RelevanceScore : 0) +
					x.PreferenceScore)
				.ThenByDescending(x =>
					dto.OrderByRating ? x.AvgRating : 0)
				.ThenByDescending(x => x.Note.CreatedAt);

			// PAGINATION
			ranked = ranked
				.Skip((dto.Page - 1) * dto.PageSize)
				.Take(dto.PageSize);

			// MAP TO DTO
			var results = ranked
				.Select(x => x.Note)
				.Adapt<IEnumerable<NoteViewDTO>>();

			return results;
		}

		public async  Task<object?> AddViewed(NoteViewedCreateDTO dto)
		{
			var transaction = await _dbContext.Database.BeginTransactionAsync();
			try {
				var noteHistory = new NoteHistory
				{
					ID = Guid.NewGuid(),
					NoteID = Guid.Parse(dto.NoteID),
					UserID = Guid.Parse(dto.UserID),
					ViewedAt = DateTime.UtcNow
				};
				_dbContext.NoteHistories.Add(noteHistory);
				await _dbContext.SaveChangesAsync();
				await transaction.CommitAsync();
				// Invalidate cache
				await _cache.RemoveAsync("history");
				return null;
			}
			catch (Exception e)
			{
				await transaction.RollbackAsync();
				throw new Exception("Error adding viewed note", e.InnerException);
			}
			finally
			{
				await transaction.DisposeAsync();
			}
		}

		public async Task<object?> GetViewHistory(Guid userId)
		{
			var history = await querryNoteHistories();
			if (history == null)
			{
				throw new Exception("No history found");
			}
			var userHistory = history.Where(h => h.UserID == userId).OrderByDescending(n => n.ViewedAt);
			if (userHistory == null)
			{
				throw new Exception("No history found for this user");
			}
			var notes = await querryNotes();
			notes = notes.Where(n => n.IsDeleted == false);
			if (notes == null)
			{
				throw new Exception("No notes found");
			}
			var result = new List<NoteViewedDTO>();
			foreach(var uh in userHistory)
			{
				NoteViewedDTO nv = new NoteViewedDTO();
				nv.viewedAt = uh.ViewedAt;
				nv.note = await Get(uh.NoteID);
				result.Add(nv);
			}
			return result;
		}
	}
}
