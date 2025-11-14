using class_library.DTO;

namespace web_api.Lib.Services.Interfaces
{
    public interface IRatingsManagerService
    {
        Task<NoteRatingViewDTO> Add(NoteRatingCreateDTO dto);
        Task<IEnumerable<NoteRatingViewDTO>> GetByNote(Guid noteId);
        Task<bool> Delete(Guid ratingId);
    }
}
