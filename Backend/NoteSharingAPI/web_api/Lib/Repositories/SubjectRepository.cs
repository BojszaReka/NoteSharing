using class_library.DTO;
using web_api.Lib.ManagerServices.Interfaces;
using web_api.Lib.Repositories.Interfaces;

namespace web_api.Lib.Repositories
{
    public class SubjectRepository : ISubjectRepository
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public SubjectRepository(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        public async Task<SubjectViewDTO> Create(SubjectCreateDTO dto)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var service = scope.ServiceProvider.GetRequiredService<ISubjectManagerService>();
            return await service.CreateAsync(dto);
        }

        public async Task<SubjectViewDTO> Update(SubjectViewDTO dto)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var service = scope.ServiceProvider.GetRequiredService<ISubjectManagerService>();
            return await service.UpdateAsync(dto);
        }

        public async Task<bool> Delete(Guid id)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var service = scope.ServiceProvider.GetRequiredService<ISubjectManagerService>();
            return await service.DeleteAsync(id);
        }

        public async Task<SubjectViewDTO?> GetById(Guid id)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var service = scope.ServiceProvider.GetRequiredService<ISubjectManagerService>();
            return await service.GetByIdAsync(id);
        }

        public async Task<IEnumerable<SubjectViewDTO>> GetAll()
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var service = scope.ServiceProvider.GetRequiredService<ISubjectManagerService>();
            return await service.GetAllAsync();
        }
    }
}
