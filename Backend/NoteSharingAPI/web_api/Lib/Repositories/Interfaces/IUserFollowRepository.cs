using class_library.DTO;

namespace web_api.Lib.Repositories.Interfaces
{
    public interface IUserFollowRepository
    {
        Task<bool> Follow(UserFollowDTO dto);
        Task<bool> Unfollow(UserFollowDTO dto);
        Task<FollowerReportDTO> GetFollowers(Guid userId);
        Task<FollowerReportDTO> GetFollowing(Guid userId);
    }
}
