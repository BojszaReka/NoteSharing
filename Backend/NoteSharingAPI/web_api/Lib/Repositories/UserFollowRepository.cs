using class_library.DTO;
using web_api.Lib.ManagerServices.Interfaces;
using web_api.Lib.Repositories.Interfaces;

namespace web_api.Lib.Repositories
{
    public class UserFollowRepository : IUserFollowRepository
    {
        private readonly IServiceScopeFactory _scopeFactory;
        public UserFollowRepository(IServiceScopeFactory scopeFactory) => _scopeFactory = scopeFactory;

        public async Task<bool> Follow(UserFollowDTO dto)
        {
            using var scope = _scopeFactory.CreateScope();
            var svc = scope.ServiceProvider.GetRequiredService<IUserFollowManagerService>();
            return await svc.FollowAsync(dto);
        }

        public async Task<bool> Unfollow(UserFollowDTO dto)
        {
            using var scope = _scopeFactory.CreateScope();
            var svc = scope.ServiceProvider.GetRequiredService<IUserFollowManagerService>();
            return await svc.UnfollowAsync(dto);
        }

        public async Task<IEnumerable<UserFollowDTO>> GetFollowers(Guid userId)
        {
            using var scope = _scopeFactory.CreateScope();
            var svc = scope.ServiceProvider.GetRequiredService<IUserFollowManagerService>();
            return await svc.GetFollowersAsync(userId);
        }

        public async Task<IEnumerable<UserFollowDTO>> GetFollowing(Guid userId)
        {
            using var scope = _scopeFactory.CreateScope();
            var svc = scope.ServiceProvider.GetRequiredService<IUserFollowManagerService>();
            return await svc.GetFollowingAsync(userId);
        }
    }
}
