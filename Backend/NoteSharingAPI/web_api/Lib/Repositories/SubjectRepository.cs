using class_library.DTO;
using web_api.Lib.ManagerServices.Interfaces;
using web_api.Lib.Repositories.Interfaces;

namespace web_api.Lib.Repositories
{
    public class SubjectRepository : ISubjectRepository
    {
        private readonly IServiceScopeFactory _scopeFactory;
        public SubjectRepository(IServiceScopeFactory scopeFactory) => _scopeFactory = scopeFactory;

        public async Task<SubjectViewDTO> Create(SubjectCreateDTO dto)
        {
            using var scope = _scopeFactory.CreateScope();
            var svc = scope.ServiceProvider.GetRequiredService<ISubjectManagerService>();
            return await svc.CreateAsync(dto);
        }

        public async Task<SubjectViewDTO> Update(SubjectViewDTO dto)
        {
            using var scope = _scopeFactory.CreateScope();
            var svc = scope.ServiceProvider.GetRequiredService<ISubjectManagerService>();
            return await svc.UpdateAsync(dto);
        }

        public async Task<bool> Delete(Guid id)
        {
            using var scope = _scopeFactory.CreateScope();
            var svc = scope.ServiceProvider.GetRequiredService<ISubjectManagerService>();
            return await svc.DeleteAsync(id);
        }

        public async Task<SubjectViewDTO?> GetById(Guid id)
        {
            using var scope = _scopeFactory.CreateScope();
            var svc = scope.ServiceProvider.GetRequiredService<ISubjectManagerService>();
            return await svc.GetByIdAsync(id);
        }

        public async Task<IEnumerable<SubjectViewDTO>> GetAll()
        {
            using var scope = _scopeFactory.CreateScope();
            var svc = scope.ServiceProvider.GetRequiredService<ISubjectManagerService>();
            return await svc.GetAllAsync();
        }
    }
}
