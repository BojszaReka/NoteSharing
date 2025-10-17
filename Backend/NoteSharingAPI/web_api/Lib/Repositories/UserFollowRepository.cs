using class_library.DTO;
using web_api.Lib.Services.Interfaces;
using web_api.Lib.Repositories.Interfaces;

namespace web_api.Lib.Repositories
{
    public class UserFollowRepository : IUserFollowRepository
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public UserFollowRepository(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        public async Task<bool> Follow(UserFollowDTO dto)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var service = scope.ServiceProvider.GetRequiredService<IUserFollowManagerService>();
            return await service.FollowAsync(dto);
        }

        public async Task<bool> Unfollow(UserFollowDTO dto)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var service = scope.ServiceProvider.GetRequiredService<IUserFollowManagerService>();
            return await service.UnfollowAsync(dto);
        }

        public async Task<IEnumerable<UserFollowDTO>> GetFollowers(Guid userId)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var service = scope.ServiceProvider.GetRequiredService<IUserFollowManagerService>();
            return await service.GetFollowersAsync(userId);
        }

        public async Task<IEnumerable<UserFollowDTO>> GetFollowing(Guid userId)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var service = scope.ServiceProvider.GetRequiredService<IUserFollowManagerService>();
            return await service.GetFollowingAsync(userId);
        }
    }
}
