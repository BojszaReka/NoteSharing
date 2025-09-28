using class_library.DTO;
using web_api.Lib.ManagerServices.Interfaces;
using web_api.Lib.Repositories.Interfaces;

namespace web_api.Lib.Repositories
{
    public class PreferenceRepository : IPreferenceRepository
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public PreferenceRepository(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        public async Task<PreferenceViewDTO> Create(PreferenceViewDTO dto)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var service = scope.ServiceProvider.GetRequiredService<IPreferenceManagerService>();
            return await service.CreateAsync(dto);
        }

        public async Task<PreferenceViewDTO> Update(PreferenceViewDTO dto)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var service = scope.ServiceProvider.GetRequiredService<IPreferenceManagerService>();
            return await service.UpdateAsync(dto);
        }

        public async Task<bool> Delete(Guid id)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var service = scope.ServiceProvider.GetRequiredService<IPreferenceManagerService>();
            return await service.DeleteAsync(id);
        }

        public async Task<PreferenceViewDTO?> GetById(Guid id)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var service = scope.ServiceProvider.GetRequiredService<IPreferenceManagerService>();
            return await service.GetByIdAsync(id);
        }
    }
}
