using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using class_library.DTO;
using class_library.Enums;
using class_library.Models;
using Mapster;
using Microsoft.EntityFrameworkCore;
using web_api.Lib.Database;
using web_api.Lib.Repositories.Interfaces;

namespace web_api.Lib.Repositories
{
    public class NoteRequestRepository : INoteRequestRepository
    {
        private readonly db_context _db;

        public NoteRequestRepository(db_context db)
        {
            _db = db;
        }

        public async Task<NoteRequestViewDTO> Create(NoteRequestCreateDTO dto)
        {
            var entity = dto.Adapt<NoteRequest>();
            _db.NoteRequests.Add(entity);
            await _db.SaveChangesAsync();

            var full = await _db.NoteRequests
                                .AsNoTracking()
                                .FirstAsync(x => x.ID == entity.ID);

            return full.Adapt<NoteRequestViewDTO>();
        }

        public async Task<NoteRequestViewDTO?> Get(Guid id)
        {
            var entity = await _db.NoteRequests
                                  .AsNoTracking()
                                  .FirstOrDefaultAsync(x => x.ID == id);
            return entity?.Adapt<NoteRequestViewDTO>();
        }

        public async Task<IEnumerable<NoteRequestViewDTO>> GetByUser(Guid userId)
        {
            var list = await _db.NoteRequests
                                .AsNoTracking()
                                .Where(x => x.CreatorUserID == userId)
                                .OrderByDescending(x => x.CreatedAt)
                                .ToListAsync();

            return list.Adapt<IEnumerable<NoteRequestViewDTO>>();
        }

        public async Task<IEnumerable<NoteRequestViewDTO>> GetRelevantRequest(Guid userId)
        {
            var list = await _db.NoteRequests
                                .AsNoTracking()
                                .Where(x => x.CreatorUserID != userId)
                                .OrderByDescending(x => x.CreatedAt)
                                .ToListAsync();

            return list.Adapt<IEnumerable<NoteRequestViewDTO>>();
        }

        public async Task<bool> ChangeRequestStatus(Guid requestId, ERequestStatus status)
        {
            var entity = await _db.NoteRequests.FirstOrDefaultAsync(x => x.ID == requestId);
            if (entity == null) return false;

            entity.Status = status;
            return await _db.SaveChangesAsync() > 0;
        }

        public async Task<NoteRequestAnswerViewDTO> AddAnswer(NoteRequestAnswerCreateDTO dto)
        {
            var entity = dto.Adapt<NoteRequestAnswer>();
            _db.NoteRequestAnswers.Add(entity);
            await _db.SaveChangesAsync();

            var full = await _db.NoteRequestAnswers
                                .AsNoTracking()
                                .FirstAsync(x => x.ID == entity.ID);

            return full.Adapt<NoteRequestAnswerViewDTO>();
        }

        public async Task<IEnumerable<NoteRequestAnswerViewDTO>> ViewAnswersByNote(Guid requestId)
        {
            var list = await _db.NoteRequestAnswers
                                .AsNoTracking()
                                .Where(a => a.RequestID == requestId)
                                .OrderByDescending(a => a.CreatedAt)
                                .ToListAsync();

            return list.Adapt<IEnumerable<NoteRequestAnswerViewDTO>>();
        }

        public async Task<IEnumerable<NoteRequestAnswerViewDTO>> ViewAnswersByUser(Guid userId)
        {
            var list = await _db.NoteRequestAnswers
                                .AsNoTracking()
                                .Where(a => a.UploaderUserID == userId)
                                .OrderByDescending(a => a.CreatedAt)
                                .ToListAsync();

            return list.Adapt<IEnumerable<NoteRequestAnswerViewDTO>>();
        }

        public async Task<bool> ChangeAnswerStatus(Guid answerId, EAnswerStatus status)
        {
            var entity = await _db.NoteRequestAnswers.FirstOrDefaultAsync(x => x.ID == answerId);
            if (entity == null) return false;

            entity.Status = status;
            return await _db.SaveChangesAsync() > 0;
        }
    }
}
