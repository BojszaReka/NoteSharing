using Microsoft.Extensions.DependencyInjection;
using class_library.DTO;
using class_library.Enums;
using web_api.Lib.Repositories.Interfaces;

namespace web_api.Lib.Repositories
{
    public class AnswerRepository : IAnswerRepository
    {
        private readonly IServiceScopeFactory _scopeFactory;
        public AnswerRepository(IServiceScopeFactory scopeFactory) => _scopeFactory = scopeFactory;

        public Task<NoteRequestAnswerViewDTO> Create(NoteRequestAnswerCreateDTO dto) => throw new NotImplementedException();
        public Task<IEnumerable<NoteRequestAnswerViewDTO>> GetByNote(Guid noteId) => throw new NotImplementedException();
        public Task<IEnumerable<NoteRequestAnswerViewDTO>> GetByUser(Guid userId) => throw new NotImplementedException();
        public Task<bool> ChangeStatus(Guid answerId, EAnswerStatus status) => throw new NotImplementedException();
    }
}
