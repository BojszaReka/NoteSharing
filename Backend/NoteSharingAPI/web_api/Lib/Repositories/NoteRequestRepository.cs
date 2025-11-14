using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using class_library.DTO;
using class_library.Enums;
using Microsoft.Extensions.DependencyInjection;
using web_api.Lib.Repositories.Interfaces;
using web_api.Lib.Services.Interfaces;

namespace web_api.Lib.Repositories
{
    public class NoteRequestRepository : INoteRequestRepository
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public NoteRequestRepository(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        public async Task<NoteRequestViewDTO> Create(NoteRequestCreateDTO dto)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var service = scope.ServiceProvider.GetRequiredService<INoteRequestManagerService>();
            return await service.CreateAsync(dto);
        }

        public async Task<NoteRequestViewDTO?> Get(Guid id)
        {
            // This method is not implemented in the service, you may need to add it
            throw new NotImplementedException("Get by ID is not implemented in the service layer");
        }

        public async Task<IEnumerable<NoteRequestViewDTO>> GetByUser(Guid userId)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var service = scope.ServiceProvider.GetRequiredService<INoteRequestManagerService>();
            return await service.GetByUserAsync(userId);
        }

        public async Task<IEnumerable<NoteRequestViewDTO>> GetByCreator(Guid userId)
        {
            // This is the same as GetByUser
            return await GetByUser(userId);
        }

        public async Task<IEnumerable<NoteRequestViewDTO>> GetRelevantRequest(Guid userId)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var service = scope.ServiceProvider.GetRequiredService<INoteRequestManagerService>();
            return await service.GetRelevantRequestAsync(userId);
        }

        public async Task<bool> ChangeRequestStatus(Guid requestId, ERequestStatus status)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var service = scope.ServiceProvider.GetRequiredService<INoteRequestManagerService>();
            return await service.ChangeRequestStatusAsync(requestId, status);
        }

        public async Task<bool> UpdateStatus(Guid requestId, ERequestStatus status)
        {
            // This is the same as ChangeRequestStatus
            return await ChangeRequestStatus(requestId, status);
        }

        public async Task<NoteRequestAnswerViewDTO> AddAnswer(NoteRequestAnswerCreateDTO dto)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var service = scope.ServiceProvider.GetRequiredService<INoteRequestManagerService>();
            return await service.AddAnswerAsync(dto);
        }

        public async Task<IEnumerable<NoteRequestAnswerViewDTO>> ViewAnswersByNote(Guid requestId)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var service = scope.ServiceProvider.GetRequiredService<INoteRequestManagerService>();
            return await service.ViewAnswersByNoteAsync(requestId);
        }

        public async Task<IEnumerable<NoteRequestAnswerViewDTO>> ViewAnswersByUser(Guid userId)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var service = scope.ServiceProvider.GetRequiredService<INoteRequestManagerService>();
            return await service.ViewAnswersByUserAsync(userId);
        }

        public async Task<bool> ChangeAnswerStatus(Guid answerId, EAnswerStatus status)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var service = scope.ServiceProvider.GetRequiredService<INoteRequestManagerService>();
            return await service.ChangeAnswerStatusAsync(answerId, status);
        }

        public async Task<bool> UpdateAnswerStatus(Guid answerId, EAnswerStatus status)
        {
            // This is the same as ChangeAnswerStatus
            return await ChangeAnswerStatus(answerId, status);
        }
    }
}
