using class_library.DTO;

namespace web_api.Lib.Services.Interfaces
{
    public interface IUserFollowManagerService
    {
        Task<bool> FollowAsync(UserFollowDTO dto);
        Task<bool> UnfollowAsync(UserFollowDTO dto);
        Task<FollowerReportDTO> GetFollowersAsync(Guid userId);
        Task<FollowerReportDTO> GetFollowingAsync(Guid userId);
    }
}
