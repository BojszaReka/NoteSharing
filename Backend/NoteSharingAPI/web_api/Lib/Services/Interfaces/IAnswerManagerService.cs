using class_library.DTO;
using class_library.Enums;

namespace web_api.Lib.Services.Interfaces
{
    public interface IAnswerManagerService
    {
        Task<NoteRequestAnswerViewDTO> Create(NoteRequestAnswerCreateDTO dto);
        Task<IEnumerable<NoteRequestAnswerViewDTO>> GetByNote(Guid noteId);
        Task<IEnumerable<NoteRequestAnswerViewDTO>> GetByUser(Guid userId);
        Task<bool> ChangeStatus(Guid answerId, EAnswerStatus status);
    }
}
