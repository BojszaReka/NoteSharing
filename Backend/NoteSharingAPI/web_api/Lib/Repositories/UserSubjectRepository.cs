using class_library.DTO;
using web_api.Lib.ManagerServices.Interfaces;
using web_api.Lib.Repositories.Interfaces;

namespace web_api.Lib.Repositories
{
    public class UserSubjectRepository : IUserSubjectRepository
    {
        private readonly IServiceScopeFactory _scopeFactory;
        public UserSubjectRepository(IServiceScopeFactory scopeFactory) => _scopeFactory = scopeFactory;

        public async Task<bool> Add(UserSubjectDTO dto)
        {
            using var scope = _scopeFactory.CreateScope();
            var svc = scope.ServiceProvider.GetRequiredService<IUserSubjectManagerService>();
            return await svc.AddAsync(dto);
        }

        public async Task<bool> Remove(UserSubjectDTO dto)
        {
            using var scope = _scopeFactory.CreateScope();
            var svc = scope.ServiceProvider.GetRequiredService<IUserSubjectManagerService>();
            return await svc.RemoveAsync(dto);
        }

        public async Task<IEnumerable<UserSubjectDTO>> GetByUser(Guid userId)
        {
            using var scope = _scopeFactory.CreateScope();
            var svc = scope.ServiceProvider.GetRequiredService<IUserSubjectManagerService>();
            return await svc.GetByUserAsync(userId);
        }

        public async Task<IEnumerable<UserSubjectDTO>> GetBySubject(Guid subjectId)
        {
            using var scope = _scopeFactory.CreateScope();
            var svc = scope.ServiceProvider.GetRequiredService<IUserSubjectManagerService>();
            return await svc.GetBySubjectAsync(subjectId);
        }
    }
}
