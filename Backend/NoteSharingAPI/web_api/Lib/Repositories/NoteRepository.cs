using Microsoft.Extensions.DependencyInjection;
using web_api.Lib.Repositories.Interfaces;
using web_api.Lib.Services.Interfaces;
using class_library.DTO;

namespace web_api.Lib.Repositories
{
    public class NoteRepository : INoteRepository
    {
        private readonly IServiceScopeFactory _sf;
        public NoteRepository(IServiceScopeFactory sf) { _sf = sf; }

        public async Task<NoteViewDTO> Create(NoteCreateDTO dto)
        {
            using var s = _sf.CreateScope();
            var svc = s.ServiceProvider.GetRequiredService<INoteManagerService>();
            return await svc.CreateAsync(dto);
        }

        public async Task<bool> Update(NoteUpdateDTO dto)
        {
            using var s = _sf.CreateScope();
            var svc = s.ServiceProvider.GetRequiredService<INoteManagerService>();
            return await svc.UpdateAsync(dto);
        }

        public async Task<bool> SoftDelete(Guid id)
        {
            using var s = _sf.CreateScope();
            var svc = s.ServiceProvider.GetRequiredService<INoteManagerService>();
            return await svc.SoftDeleteAsync(id);
        }

        public async Task<NoteViewDTO> Get(Guid id)
        {
            using var s = _sf.CreateScope();
            var svc = s.ServiceProvider.GetRequiredService<INoteManagerService>();
            return await svc.GetAsync(id);
        }

        public async Task<IEnumerable<NoteViewDTO>> GetByAuthor(Guid userId)
        {
            using var s = _sf.CreateScope();
            var svc = s.ServiceProvider.GetRequiredService<INoteManagerService>();
            return await svc.GetByAuthorAsync(userId);
        }

        public async Task<IEnumerable<NoteViewDTO>> GetBySubject(Guid subjectId)
        {
            using var s = _sf.CreateScope();
            var svc = s.ServiceProvider.GetRequiredService<INoteManagerService>();
            return await svc.GetBySubjectAsync(subjectId);
        }

        public async Task<IEnumerable<NoteViewDTO>> Search(Guid? institutionId, Guid? subjectId, string? text)
        {
            using var s = _sf.CreateScope();
            var svc = s.ServiceProvider.GetRequiredService<INoteManagerService>();
            return await svc.SearchAsync(institutionId, subjectId, text);
        }

        public async Task<NoteRatingViewDTO> Rate(NoteRatingCreateDTO dto)
        {
            using var s = _sf.CreateScope();
            var svc = s.ServiceProvider.GetRequiredService<INoteManagerService>();
            return await svc.RateAsync(dto);
        }

        public async Task<IEnumerable<NoteRatingViewDTO>> GetRatings(Guid noteId)
        {
            using var s = _sf.CreateScope();
            var svc = s.ServiceProvider.GetRequiredService<INoteManagerService>();
            return await svc.GetRatingsAsync(noteId);
        }

        public async Task<bool> DeleteRating(Guid ratingId)
        {
            using var s = _sf.CreateScope();
            var svc = s.ServiceProvider.GetRequiredService<INoteManagerService>();
            return await svc.DeleteRatingAsync(ratingId);
        }
    }
}
