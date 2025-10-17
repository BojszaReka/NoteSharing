using class_library.DTO;

namespace web_api.Lib.Repositories.Interfaces
{
    public interface IUserFollowRepository
    {
        Task<bool> Follow(UserFollowDTO dto);
        Task<bool> Unfollow(UserFollowDTO dto);
        Task<IEnumerable<UserFollowDTO>> GetFollowers(Guid userId);
        Task<IEnumerable<UserFollowDTO>> GetFollowing(Guid userId);
    }
}
