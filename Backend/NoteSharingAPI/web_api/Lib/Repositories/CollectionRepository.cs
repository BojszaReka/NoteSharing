using Microsoft.Extensions.DependencyInjection;
using web_api.Lib.Repositories.Interfaces;
using web_api.Lib.Services.Interfaces;
using class_library.DTO;

namespace web_api.Lib.Repositories
{
    public class CollectionRepository : ICollectionRepository
    {
        private readonly IServiceScopeFactory _sf;
        public CollectionRepository(IServiceScopeFactory sf) { _sf = sf; }

        public async Task<CollectionViewDTO> Create(CollectionCreateDTO dto)
        {
            using var s = _sf.CreateScope();
            var svc = s.ServiceProvider.GetRequiredService<ICollectionManagerService>();
            return await svc.CreateAsync(dto);
        }

        public async Task<bool> Update(CollectionViewDTO dto)
        {
            using var s = _sf.CreateScope();
            var svc = s.ServiceProvider.GetRequiredService<ICollectionManagerService>();
            return await svc.UpdateAsync(dto);
        }

        public async Task<bool> Delete(Guid id)
        {
            using var s = _sf.CreateScope();
            var svc = s.ServiceProvider.GetRequiredService<ICollectionManagerService>();
            return await svc.DeleteAsync(id);
        }

        public async Task<CollectionViewDTO> Get(Guid id)
        {
            using var s = _sf.CreateScope();
            var svc = s.ServiceProvider.GetRequiredService<ICollectionManagerService>();
            return await svc.GetAsync(id);
        }

        public async Task<IEnumerable<CollectionViewDTO>> GetByUser(Guid userId)
        {
            using var s = _sf.CreateScope();
            var svc = s.ServiceProvider.GetRequiredService<ICollectionManagerService>();
            return await svc.GetByUserAsync(userId);
        }

        public async Task<bool> AddNote(CollectionNoteDTO dto)
        {
            using var s = _sf.CreateScope();
            var svc = s.ServiceProvider.GetRequiredService<ICollectionManagerService>();
            return await svc.AddNoteAsync(dto);
        }

        public async Task<bool> RemoveNote(CollectionNoteDTO dto)
        {
            using var s = _sf.CreateScope();
            var svc = s.ServiceProvider.GetRequiredService<ICollectionManagerService>();
            return await svc.RemoveNoteAsync(dto);
        }
    }
}
