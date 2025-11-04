using class_library.DTO;
using web_api.Lib.Services.Interfaces;

namespace web_api.Lib.Services
{
    public class RatingsManagerService : IRatingsManagerService
    {
        public Task<NoteRatingViewDTO> Add(NoteRatingCreateDTO dto) => throw new NotImplementedException();
        public Task<IEnumerable<NoteRatingViewDTO>> GetByNote(Guid noteId) => throw new NotImplementedException();
        public Task<bool> Delete(Guid ratingId) => throw new NotImplementedException();
    }
}
