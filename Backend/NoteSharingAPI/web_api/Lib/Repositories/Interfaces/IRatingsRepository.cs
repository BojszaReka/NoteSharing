using class_library.DTO;

namespace web_api.Lib.Repositories.Interfaces
{
    public interface IRatingsRepository
    {
        Task<NoteRatingViewDTO> Add(NoteRatingCreateDTO dto);
        Task<IEnumerable<NoteRatingViewDTO>> GetByNote(Guid noteId);
        Task<bool> Delete(Guid ratingId);
    }
}
