using class_library.DTO;
using web_api.Lib.ManagerServices.Interfaces;
using web_api.Lib.Repositories.Interfaces;

namespace web_api.Lib.Repositories
{
    public class InstitutionRepository : IInstitutionRepository
    {
        private readonly IServiceScopeFactory _scopeFactory;
        public InstitutionRepository(IServiceScopeFactory scopeFactory) => _scopeFactory = scopeFactory;

        public async Task<InstitutionViewDTO> Create(InstitutionCreateDTO dto)
        {
            using var scope = _scopeFactory.CreateScope();
            var svc = scope.ServiceProvider.GetRequiredService<IInstitutionManagerService>();
            return await svc.CreateAsync(dto);
        }

        public async Task<InstitutionViewDTO> Update(InstitutionViewDTO dto)
        {
            using var scope = _scopeFactory.CreateScope();
            var svc = scope.ServiceProvider.GetRequiredService<IInstitutionManagerService>();
            return await svc.UpdateAsync(dto);
        }

        public async Task<bool> Delete(Guid id)
        {
            using var scope = _scopeFactory.CreateScope();
            var svc = scope.ServiceProvider.GetRequiredService<IInstitutionManagerService>();
            return await svc.DeleteAsync(id);
        }

        public async Task<InstitutionViewDTO?> GetById(Guid id)
        {
            using var scope = _scopeFactory.CreateScope();
            var svc = scope.ServiceProvider.GetRequiredService<IInstitutionManagerService>();
            return await svc.GetByIdAsync(id);
        }

        public async Task<IEnumerable<InstitutionViewDTO>> GetAll()
        {
            using var scope = _scopeFactory.CreateScope();
            var svc = scope.ServiceProvider.GetRequiredService<IInstitutionManagerService>();
            return await svc.GetAllAsync();
        }
    }
}
