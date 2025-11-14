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
using web_api.Lib.Services.Interfaces;

namespace web_api.Lib.Services
{
    public class NoteRequestManagerService : INoteRequestManagerService
    {
        private readonly db_context _db;

        public NoteRequestManagerService(db_context db)
        {
            _db = db;
        }

        public async Task<NoteRequestViewDTO> CreateAsync(NoteRequestCreateDTO dto)
        {
            var entity = dto.Adapt<NoteRequest>();
            _db.NoteRequests.Add(entity);
            await _db.SaveChangesAsync();

            var full = await _db.NoteRequests
                                .AsNoTracking()
                                .FirstAsync(x => x.ID == entity.ID);

            return full.Adapt<NoteRequestViewDTO>();
        }

        // modifyRequest
        public async Task<NoteRequestViewDTO> ModifyAsync(NoteRequestCreateDTO dto)
        {
            var entity = await _db.NoteRequests.FirstOrDefaultAsync(x => x.ID == dto.CreatorUserID);
            if (entity == null)
                throw new KeyNotFoundException("Request not found.");

            dto.Adapt(entity);
            await _db.SaveChangesAsync();

            var full = await _db.NoteRequests
                                .AsNoTracking()
                                .FirstAsync(x => x.ID == entity.ID);

            return full.Adapt<NoteRequestViewDTO>();
        }

        // changeRequestStatus
        public async Task<bool> ChangeRequestStatusAsync(Guid requestId, ERequestStatus status)
        {
            var entity = await _db.NoteRequests.FirstOrDefaultAsync(x => x.ID == requestId);
            if (entity == null) return false;

            entity.Status = status;
            return await _db.SaveChangesAsync() > 0;
        }

        // getRequest -> by userid (the requests the user made)
        public async Task<IEnumerable<NoteRequestViewDTO>> GetByUserAsync(Guid userId)
        {
            var list = await _db.NoteRequests
                                .AsNoTracking()
                                .Where(x => x.CreatorUserID == userId)
                                .OrderByDescending(x => x.CreatedAt)
                                .ToListAsync();

            return list.Adapt<IEnumerable<NoteRequestViewDTO>>();
        }

        // getRelevantRequest -> by userid (requests a user may provide answer for)
        // Itt "releváns"-nak tekintjük azokat, amelyeket nem ő hozott létre.
        public async Task<IEnumerable<NoteRequestViewDTO>> GetRelevantRequestAsync(Guid userId)
        {
            var list = await _db.NoteRequests
                                .AsNoTracking()
                                .Where(x => x.CreatorUserID != userId)
                                .OrderByDescending(x => x.CreatedAt)
                                .ToListAsync();

            return list.Adapt<IEnumerable<NoteRequestViewDTO>>();
        }

        // addAnswer
        public async Task<NoteRequestAnswerViewDTO> AddAnswerAsync(NoteRequestAnswerCreateDTO dto)
        {
            var entity = dto.Adapt<NoteRequestAnswer>();
            _db.NoteRequestAnswers.Add(entity);
            await _db.SaveChangesAsync();

            var full = await _db.NoteRequestAnswers
                                .AsNoTracking()
                                .FirstAsync(x => x.ID == entity.ID);

            return full.Adapt<NoteRequestAnswerViewDTO>();
        }

        // viewAnswers -> by noteid (answers provided for a note)
        public async Task<IEnumerable<NoteRequestAnswerViewDTO>> ViewAnswersByNoteAsync(Guid requestId)
        {
            var list = await _db.NoteRequestAnswers
                                .AsNoTracking()
                                .Where(a => a.RequestID == requestId)
                                .OrderByDescending(a => a.CreatedAt)
                                .ToListAsync();

            return list.Adapt<IEnumerable<NoteRequestAnswerViewDTO>>();
        }


        // viewAnswers -> by userid (answers provided by the user)
        public async Task<IEnumerable<NoteRequestAnswerViewDTO>> ViewAnswersByUserAsync(Guid userId)
        {
            var list = await _db.NoteRequestAnswers
                                .AsNoTracking()
                                .Where(a => a.UploaderUserID == userId)
                                .OrderByDescending(a => a.CreatedAt)
                                .ToListAsync();

            return list.Adapt<IEnumerable<NoteRequestAnswerViewDTO>>();
        }

        // changeAnswerStatus
        public async Task<bool> ChangeAnswerStatusAsync(Guid answerId, EAnswerStatus status)
        {
            var entity = await _db.NoteRequestAnswers.FirstOrDefaultAsync(x => x.ID == answerId);
            if (entity == null) return false;

            entity.Status = status;
            return await _db.SaveChangesAsync() > 0;
        }
    }
}
