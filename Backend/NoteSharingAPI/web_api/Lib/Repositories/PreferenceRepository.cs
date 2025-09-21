using class_library.DTO;
using web_api.Lib.ManagerServices.Interfaces;
using web_api.Lib.Repositories.Interfaces;

namespace web_api.Lib.Repositories
{
    public class PreferenceRepository : IPreferenceRepository
    {
        private readonly IServiceScopeFactory _scopeFactory;
        public PreferenceRepository(IServiceScopeFactory scopeFactory) => _scopeFactory = scopeFactory;

        public async Task<PreferenceViewDTO> Create(PreferenceViewDTO dto)
        {
            using var scope = _scopeFactory.CreateScope();
            var svc = scope.ServiceProvider.GetRequiredService<IPreferenceManagerService>();
            return await svc.CreateAsync(dto);
        }

        public async Task<PreferenceViewDTO> Update(PreferenceViewDTO dto)
        {
            using var scope = _scopeFactory.CreateScope();
            var svc = scope.ServiceProvider.GetRequiredService<IPreferenceManagerService>();
            return await svc.UpdateAsync(dto);
        }

        public async Task<bool> Delete(Guid id)
        {
            using var scope = _scopeFactory.CreateScope();
            var svc = scope.ServiceProvider.GetRequiredService<IPreferenceManagerService>();
            return await svc.DeleteAsync(id);
        }

        public async Task<PreferenceViewDTO?> GetById(Guid id)
        {
            using var scope = _scopeFactory.CreateScope();
            var svc = scope.ServiceProvider.GetRequiredService<IPreferenceManagerService>();
            return await svc.GetByIdAsync(id);
        }
    }
}
