using class_library.DTO;
using web_api.Lib.ManagerServices.Interfaces;

namespace web_api.Lib.ManagerServices
{
    public class UserFollowManagerService : IUserFollowManagerService
    {
        public Task<bool> FollowAsync(UserFollowDTO dto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UnfollowAsync(UserFollowDTO dto)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserFollowDTO>> GetFollowersAsync(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserFollowDTO>> GetFollowingAsync(Guid userId)
        {
            throw new NotImplementedException();
        }
    }
}
