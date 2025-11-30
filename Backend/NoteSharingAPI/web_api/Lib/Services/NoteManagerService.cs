using class_library.DTO;
using class_library.Models;
using Mapster;
using Microsoft.EntityFrameworkCore;
using web_api.Lib.Database;
using web_api.Lib.Services.Interfaces;

namespace web_api.Lib.Services
{
    public class NoteManagerService : INoteManagerService
    {
        private readonly db_context _db;

        public NoteManagerService(db_context db)
        {
            _db = db;
        }

        public async Task<NoteViewDTO> CreateAsync(NoteCreateDTO dto)
        {
            var e = dto.Adapt<Note>();
            _db.Notes.Add(e);
            await _db.SaveChangesAsync();
            return (await GetAsync(e.ID))!;
        }

        public async Task<bool> UpdateAsync(NoteUpdateDTO dto)
        {
            var e = await _db.Notes.FirstOrDefaultAsync(x => x.ID == dto.ID);
            if (e == null) return false;
            e.Content = dto.Content;
            e.Title = dto.Title;
            e.Description = dto.Description;
            e.SubjectID = dto.SubjectID;
            e.InstitutionID = dto.InstitutionID;
            e.IsDeleted = dto.IsDeleted;
            e.UpdatedAt = DateTime.UtcNow;
            return await _db.SaveChangesAsync() > 0;
        }

        public async Task<bool> SoftDeleteAsync(Guid id)
        {
            var e = await _db.Notes.FirstOrDefaultAsync(x => x.ID == id);
            if (e == null) return false;
            e.IsDeleted = true;
            e.UpdatedAt = DateTime.UtcNow;
            return await _db.SaveChangesAsync() > 0;
        }

        public async Task<NoteViewDTO> GetAsync(Guid id)
        {
            var e = await _db.Notes
                .AsNoTracking()
                .Include(n => n.Author)
                .Include(n => n.Ratings).ThenInclude(r => r.User)
                .FirstOrDefaultAsync(n => n.ID == id && !n.IsDeleted);
            return e?.Adapt<NoteViewDTO>();
        }

        public async Task<IEnumerable<NoteViewDTO>> GetByAuthorAsync(Guid userId)
        {
            var list = await _db.Notes
                .AsNoTracking()
                .Include(n => n.Author)
                .Include(n => n.Ratings)
                .Where(n => n.AuthorUserID == userId && !n.IsDeleted)
                .ToListAsync();
            return list.Adapt<IEnumerable<NoteViewDTO>>();
        }

        public async Task<IEnumerable<NoteViewDTO>> GetBySubjectAsync(Guid subjectId)
        {
            var list = await _db.Notes
                .AsNoTracking()
                .Include(n => n.Author)
                .Include(n => n.Ratings)
                .Where(n => n.SubjectID == subjectId && !n.IsDeleted)
                .ToListAsync();
            return list.Adapt<IEnumerable<NoteViewDTO>>();
        }

        public async Task<IEnumerable<NoteViewDTO>> SearchAsync(Guid? institutionId, Guid? subjectId, string? text)
        {
            var q = _db.Notes.AsNoTracking()
                .Include(n => n.Author)
                .Include(n => n.Ratings)
                .Where(n => !n.IsDeleted);
            if (institutionId.HasValue) q = q.Where(n => n.InstitutionID == institutionId.Value);
            if (subjectId.HasValue) q = q.Where(n => n.SubjectID == subjectId.Value);
            if (!string.IsNullOrWhiteSpace(text))
                q = q.Where(n => n.Title.Contains(text) || n.Description.Contains(text) || n.Content.Contains(text));
            var list = await q.ToListAsync();
            return list.Adapt<IEnumerable<NoteViewDTO>>();
        }

        public async Task<NoteRatingViewDTO> RateAsync(NoteRatingCreateDTO dto)
        {
            var existing = await _db.NoteRatings.FirstOrDefaultAsync(x => x.NoteID == dto.NoteID && x.UserID == dto.UserID);
            if (existing == null)
            {
                var r = dto.Adapt<NoteRating>();
                _db.NoteRatings.Add(r);
                await _db.SaveChangesAsync();
                var full = await _db.NoteRatings.AsNoTracking().Include(x => x.User).FirstAsync(x => x.ID == r.ID);
                return full.Adapt<NoteRatingViewDTO>();
            }
            existing.Stars = dto.Stars;
            existing.Review = dto.Review;
            await _db.SaveChangesAsync();
            var upd = await _db.NoteRatings.AsNoTracking().Include(x => x.User).FirstAsync(x => x.ID == existing.ID);
            return upd.Adapt<NoteRatingViewDTO>();
        }

        public async Task<IEnumerable<NoteRatingViewDTO>> GetRatingsAsync(Guid noteId)
        {
            var list = await _db.NoteRatings.AsNoTracking()
                .Include(x => x.User)
                .Where(x => x.NoteID == noteId)
                .OrderByDescending(x => x.CreatedAt)
                .ToListAsync();
            return list.Adapt<IEnumerable<NoteRatingViewDTO>>();
        }

        public async Task<bool> DeleteRatingAsync(Guid ratingId)
        {
            var e = await _db.NoteRatings.FindAsync(ratingId);
            if (e == null) return false;
            _db.NoteRatings.Remove(e);
            return await _db.SaveChangesAsync() > 0;
        }

		public Task<object?> AddReview(NoteRatingCreateDTO dto)
		{
			throw new NotImplementedException();
		}

		public Task<object?> Dislike(NoteLikeDTO dto)
		{
			throw new NotImplementedException();
		}

		public Task<NoteViewDTO> GetById(Guid id)
		{
			throw new NotImplementedException();
		}

		public Task<ICollection<NoteViewDTO>> GetAll()
		{
			throw new NotImplementedException();
		}

		public Task<object?> Like(NoteLikeDTO dto)
		{
			throw new NotImplementedException();
		}
	}
}
