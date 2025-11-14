using class_library.DTO;
using class_library.Models;
using Mapster;
using Microsoft.EntityFrameworkCore;
using web_api.Lib.Database;
using web_api.Lib.Services.Interfaces;

namespace web_api.Lib.Services
{
    public class CollectionManagerService : ICollectionManagerService
    {
        private readonly db_context _db;

        public CollectionManagerService(db_context db)
        {
            _db = db;
        }

        public async Task<CollectionViewDTO> CreateAsync(CollectionCreateDTO dto)
        {
            var e = dto.Adapt<Collection>();
            _db.Collections.Add(e);
            await _db.SaveChangesAsync();
            var full = await _db.Collections.AsNoTracking().FirstAsync(x => x.ID == e.ID);
            return full.Adapt<CollectionViewDTO>();
        }

        public async Task<bool> UpdateAsync(CollectionViewDTO dto)
        {
            var e = await _db.Collections.FirstOrDefaultAsync(x => x.ID == dto.ID);
            if (e == null) return false;
            e.Name = dto.Name;
            e.Title = dto.Title;
            e.Private = dto.Private;
            return await _db.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var e = await _db.Collections.FindAsync(id);
            if (e == null) return false;
            _db.Collections.Remove(e);
            return await _db.SaveChangesAsync() > 0;
        }

        public async Task<CollectionViewDTO> GetAsync(Guid id)
        {
            var e = await _db.Collections.AsNoTracking().FirstOrDefaultAsync(x => x.ID == id);
            return e?.Adapt<CollectionViewDTO>();
        }

        public async Task<IEnumerable<CollectionViewDTO>> GetByUserAsync(Guid userId)
        {
            var list = await _db.Collections.AsNoTracking().Where(x => x.UserID == userId).ToListAsync();
            return list.Adapt<IEnumerable<CollectionViewDTO>>();
        }

        public async Task<bool> AddNoteAsync(CollectionNoteDTO dto)
        {
            var exists = await _db.CollectionNotes.FindAsync(dto.NoteID, dto.CollectionID);
            if (exists != null) return true;
            _db.CollectionNotes.Add(new CollectionNote { NoteID = dto.NoteID, CollectionID = dto.CollectionID });
            return await _db.SaveChangesAsync() > 0;
        }

        public async Task<bool> RemoveNoteAsync(CollectionNoteDTO dto)
        {
            var e = await _db.CollectionNotes.FindAsync(dto.NoteID, dto.CollectionID);
            if (e == null) return false;
            _db.CollectionNotes.Remove(e);
            return await _db.SaveChangesAsync() > 0;
        }
    }
}
