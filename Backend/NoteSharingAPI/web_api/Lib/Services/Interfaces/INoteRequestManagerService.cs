using class_library.DTO;
using class_library.Enums;

namespace web_api.Lib.Services.Interfaces
{
    public interface INoteRequestManagerService
    {
        Task<NoteRequestViewDTO> CreateAsync(NoteRequestCreateDTO dto);
        Task<NoteRequestViewDTO> ModifyAsync(NoteRequestCreateDTO dto);
        Task<bool> ChangeRequestStatusAsync(Guid requestId, ERequestStatus status);
        Task<IEnumerable<NoteRequestViewDTO>> GetByUserAsync(Guid userId);
        Task<IEnumerable<NoteRequestViewDTO>> GetRelevantRequestAsync(Guid userId);

        Task<NoteRequestAnswerViewDTO> AddAnswerAsync(NoteRequestAnswerCreateDTO dto);
        Task<IEnumerable<NoteRequestAnswerViewDTO>> ViewAnswersByNoteAsync(Guid noteId);
        Task<IEnumerable<NoteRequestAnswerViewDTO>> ViewAnswersByUserAsync(Guid userId);
        Task<bool> ChangeAnswerStatusAsync(Guid answerId, EAnswerStatus status);
		Task<object?> GetByCreator(Guid userId);
		Task<NoteRequestViewDTO> Get(Guid userId);
		Task<object?> GetRelevantRequestByUser(Guid userId);
		Task<object?> ModifyRequest(NoteRequestCreateDTO dto);
		Task<bool> UpdateAnswerStatus(Guid answerId, EAnswerStatus newStatus);
		Task<object?> UpdateStatus(Guid requestId, ERequestStatus newStatus);
	}
}
