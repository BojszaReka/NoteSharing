using class_library.DTO;
using web_api.Lib.ManagerServices.Interfaces;
using web_api.Lib.Repositories.Interfaces;

namespace web_api.Lib.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public UserRepository(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        public async Task<UserViewDTO> Create(UserCreateDTO dto)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var service = scope.ServiceProvider.GetRequiredService<IUserManagerService>();
            return await service.CreateAsync(dto);
        }

        public async Task<UserViewDTO> Update(UserUpdateDTO dto)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var service = scope.ServiceProvider.GetRequiredService<IUserManagerService>();
            return await service.UpdateAsync(dto);
        }

        public async Task<bool> Delete(Guid id)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var service = scope.ServiceProvider.GetRequiredService<IUserManagerService>();
            return await service.DeleteAsync(id);
        }

        public async Task<UserViewDTO?> GetById(Guid id)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var service = scope.ServiceProvider.GetRequiredService<IUserManagerService>();
            return await service.GetByIdAsync(id);
        }

        public async Task<UserViewDTO?> GetByUserName(string userName)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var service = scope.ServiceProvider.GetRequiredService<IUserManagerService>();
            return await service.GetByUserNameAsync(userName);
        }

        public async Task<IEnumerable<UserViewDTO>> GetAll()
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var service = scope.ServiceProvider.GetRequiredService<IUserManagerService>();
            return await service.GetAllAsync();
        }

        public async Task<bool> Follow(UserFollowDTO dto)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var service = scope.ServiceProvider.GetRequiredService<IUserManagerService>();
            return await service.FollowAsync(dto);
        }
    }
}
