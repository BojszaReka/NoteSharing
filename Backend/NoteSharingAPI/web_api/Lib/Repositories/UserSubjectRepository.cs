using class_library.DTO;
using web_api.Lib.Services.Interfaces;
using web_api.Lib.Repositories.Interfaces;

namespace web_api.Lib.Repositories
{
    public class UserSubjectRepository : IUserSubjectRepository
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public UserSubjectRepository(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        public async Task<bool> Add(UserSubjectDTO dto)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var service = scope.ServiceProvider.GetRequiredService<IUserSubjectManagerService>();
            return await service.AddAsync(dto);
        }

        public async Task<bool> Remove(UserSubjectDTO dto)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var service = scope.ServiceProvider.GetRequiredService<IUserSubjectManagerService>();
            return await service.RemoveAsync(dto);
        }

        public async Task<IEnumerable<UserSubjectDTO>> GetByUser(Guid userId)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var service = scope.ServiceProvider.GetRequiredService<IUserSubjectManagerService>();
            return await service.GetByUserAsync(userId);
        }

        public async Task<IEnumerable<UserSubjectDTO>> GetBySubject(Guid subjectId)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var service = scope.ServiceProvider.GetRequiredService<IUserSubjectManagerService>();
            return await service.GetBySubjectAsync(subjectId);
        }
    }
}
