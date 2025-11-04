using class_library.DTO;

namespace web_api.Lib.Services.Interfaces
{
    public interface INoteManagerService
    {
        Task<NoteViewDTO> CreateAsync(NoteCreateDTO dto);
        Task<bool> UpdateAsync(NoteUpdateDTO dto);
        Task<bool> SoftDeleteAsync(Guid id);
        Task<NoteViewDTO> GetAsync(Guid id);
        Task<IEnumerable<NoteViewDTO>> GetByAuthorAsync(Guid userId);
        Task<IEnumerable<NoteViewDTO>> GetBySubjectAsync(Guid subjectId);
        Task<IEnumerable<NoteViewDTO>> SearchAsync(Guid? institutionId, Guid? subjectId, string? text);
        Task<NoteRatingViewDTO> RateAsync(NoteRatingCreateDTO dto);
        Task<IEnumerable<NoteRatingViewDTO>> GetRatingsAsync(Guid noteId);
        Task<bool> DeleteRatingAsync(Guid ratingId);
    }
}
