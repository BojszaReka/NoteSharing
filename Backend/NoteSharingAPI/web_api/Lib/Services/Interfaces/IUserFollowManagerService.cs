using class_library.DTO;

namespace web_api.Lib.ManagerServices.Interfaces
{
    public interface IUserFollowManagerService
    {
        Task<bool> FollowAsync(UserFollowDTO dto);
        Task<bool> UnfollowAsync(UserFollowDTO dto);
        Task<IEnumerable<UserFollowDTO>> GetFollowersAsync(Guid userId);
        Task<IEnumerable<UserFollowDTO>> GetFollowingAsync(Guid userId);
    }
}
