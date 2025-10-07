using class_library.DTO;

namespace web_api.Lib.Services.Interfaces
{
    public interface IUserManagerService
    {
        Task<UserViewDTO> CreateAsync(UserCreateDTO dto);
        Task<UserViewDTO> UpdateAsync(UserUpdateDTO dto);
        Task<bool> DeleteAsync(Guid id);
        Task<UserViewDTO?> GetByIdAsync(Guid id);
        Task<UserViewDTO?> GetByUserNameAsync(string userName);
        Task<IEnumerable<UserViewDTO>> GetAllAsync();

        Task<bool> FollowAsync(UserFollowDTO dto);
    }
}
