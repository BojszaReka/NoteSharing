using class_library.DTO;
using web_api.Lib.ManagerServices.Interfaces;
using web_api.Lib.Repositories.Interfaces;

namespace web_api.Lib.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IServiceScopeFactory _scopeFactory;
        public UserRepository(IServiceScopeFactory scopeFactory) => _scopeFactory = scopeFactory;

        public async Task<UserViewDTO> Create(UserCreateDTO dto)
        {
            using var scope = _scopeFactory.CreateScope();
            var svc = scope.ServiceProvider.GetRequiredService<IUserManagerService>();
            return await svc.CreateAsync(dto);
        }

        public async Task<UserViewDTO> Update(UserUpdateDTO dto)
        {
            using var scope = _scopeFactory.CreateScope();
            var svc = scope.ServiceProvider.GetRequiredService<IUserManagerService>();
            return await svc.UpdateAsync(dto);
        }

        public async Task<bool> Delete(Guid id)
        {
            using var scope = _scopeFactory.CreateScope();
            var svc = scope.ServiceProvider.GetRequiredService<IUserManagerService>();
            return await svc.DeleteAsync(id);
        }

        public async Task<UserViewDTO?> GetById(Guid id)
        {
            using var scope = _scopeFactory.CreateScope();
            var svc = scope.ServiceProvider.GetRequiredService<IUserManagerService>();
            return await svc.GetByIdAsync(id);
        }

        public async Task<UserViewDTO?> GetByUserName(string userName)
        {
            using var scope = _scopeFactory.CreateScope();
            var svc = scope.ServiceProvider.GetRequiredService<IUserManagerService>();
            return await svc.GetByUserNameAsync(userName);
        }

        public async Task<IEnumerable<UserViewDTO>> GetAll()
        {
            using var scope = _scopeFactory.CreateScope();
            var svc = scope.ServiceProvider.GetRequiredService<IUserManagerService>();
            return await svc.GetAllAsync();
        }

        public async Task<bool> Follow(UserFollowDTO dto)
        {
            using var scope = _scopeFactory.CreateScope();
            var svc = scope.ServiceProvider.GetRequiredService<IUserManagerService>();
            return await svc.FollowAsync(dto);
        }
    }
}
