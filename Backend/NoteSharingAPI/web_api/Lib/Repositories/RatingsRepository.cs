using Microsoft.Extensions.DependencyInjection;
using class_library.DTO;
using web_api.Lib.Repositories.Interfaces;

namespace web_api.Lib.Repositories
{
    public class RatingsRepository : IRatingsRepository
    {
        private readonly IServiceScopeFactory _scopeFactory;
        public RatingsRepository(IServiceScopeFactory scopeFactory) => _scopeFactory = scopeFactory;

        public Task<NoteRatingViewDTO> Add(NoteRatingCreateDTO dto) => throw new NotImplementedException();
        public Task<IEnumerable<NoteRatingViewDTO>> GetByNote(Guid noteId) => throw new NotImplementedException();
        public Task<bool> Delete(Guid ratingId) => throw new NotImplementedException();
    }
}
