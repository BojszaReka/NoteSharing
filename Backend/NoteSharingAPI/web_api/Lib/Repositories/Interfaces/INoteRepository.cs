using class_library.DTO;

namespace web_api.Lib.Repositories.Interfaces
{
    public interface INoteRepository
    {
        Task<NoteViewDTO> Create(NoteCreateDTO dto);
        Task<bool> Update(NoteUpdateDTO dto);
        Task<bool> SoftDelete(Guid id);
        Task<NoteViewDTO> Get(Guid id);
        Task<IEnumerable<NoteViewDTO>> GetByAuthor(Guid userId);
        Task<IEnumerable<NoteViewDTO>> GetBySubject(Guid subjectId);
        Task<IEnumerable<NoteViewDTO>> Search(Guid? institutionId, Guid? subjectId, string? text);
        Task<NoteRatingViewDTO> Rate(NoteRatingCreateDTO dto);
        Task<IEnumerable<NoteRatingViewDTO>> GetRatings(Guid noteId);
        Task<bool> DeleteRating(Guid ratingId);
    }
}
