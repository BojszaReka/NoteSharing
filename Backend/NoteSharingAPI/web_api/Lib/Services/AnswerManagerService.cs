using class_library.DTO;
using class_library.Enums;
using web_api.Lib.Services.Interfaces;

namespace web_api.Lib.Services
{
    public class AnswerManagerService : IAnswerManagerService
    {
        public Task<NoteRequestAnswerViewDTO> Create(NoteRequestAnswerCreateDTO dto) => throw new NotImplementedException();
        public Task<IEnumerable<NoteRequestAnswerViewDTO>> GetByNote(Guid noteId) => throw new NotImplementedException();
        public Task<IEnumerable<NoteRequestAnswerViewDTO>> GetByUser(Guid userId) => throw new NotImplementedException();
        public Task<bool> ChangeStatus(Guid answerId, EAnswerStatus status) => throw new NotImplementedException();
    }
}
