using class_library.DTO;
using web_api.Lib.ManagerServices.Interfaces;
using web_api.Lib.Repositories.Interfaces;

namespace web_api.Lib.Repositories
{
    public class InstitutionRepository : IInstitutionRepository
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public InstitutionRepository(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        public async Task<InstitutionViewDTO> Create(InstitutionCreateDTO dto)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var service = scope.ServiceProvider.GetRequiredService<IInstitutionManagerService>();
            return await service.CreateAsync(dto);
        }

        public async Task<InstitutionViewDTO> Update(InstitutionViewDTO dto)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var service = scope.ServiceProvider.GetRequiredService<IInstitutionManagerService>();
            return await service.UpdateAsync(dto);
        }

        public async Task<bool> Delete(Guid id)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var service = scope.ServiceProvider.GetRequiredService<IInstitutionManagerService>();
            return await service.DeleteAsync(id);
        }

        public async Task<InstitutionViewDTO?> GetById(Guid id)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var service = scope.ServiceProvider.GetRequiredService<IInstitutionManagerService>();
            return await service.GetByIdAsync(id);
        }

        public async Task<IEnumerable<InstitutionViewDTO>> GetAll()
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var service = scope.ServiceProvider.GetRequiredService<IInstitutionManagerService>();
            return await service.GetAllAsync();
        }
    }
}
