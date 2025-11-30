using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using class_library.DTO;
using class_library.Enums;

namespace web_api.Lib.Repositories.Interfaces
{
    public interface INoteRequestRepository
    {
        Task<NoteRequestViewDTO> Create(NoteRequestCreateDTO dto);
        Task<NoteRequestViewDTO?> Get(Guid id);
        Task<IEnumerable<NoteRequestViewDTO>> GetByUser(Guid userId);
        Task<IEnumerable<NoteRequestViewDTO>> GetRelevantRequest(Guid userId);
        Task<bool> ChangeRequestStatus(Guid requestId, ERequestStatus status);

        Task<NoteRequestAnswerViewDTO> AddAnswer(NoteRequestAnswerCreateDTO dto);
        Task<IEnumerable<NoteRequestAnswerViewDTO>> ViewAnswersByNote(Guid requestId);
        Task<IEnumerable<NoteRequestAnswerViewDTO>> ViewAnswersByUser(Guid userId);
        Task<bool> ChangeAnswerStatus(Guid answerId, EAnswerStatus status);
		Task<object?> UpdateStatus(Guid requestId, ERequestStatus newStatus);
		Task<object?> GetRelevantRequestByUser(Guid userId);
		Task<object?> ModifyRequest(NoteRequestModifyDTO dto);
		Task<IEnumerable<NoteRequestViewDTO>> GetByCreator(Guid userId);
		Task<bool> UpdateAnswerStatus(Guid answerId, EAnswerStatus status);
	}
}
