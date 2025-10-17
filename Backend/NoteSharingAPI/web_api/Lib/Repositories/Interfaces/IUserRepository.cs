using class_library.DTO;

namespace web_api.Lib.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<UserViewDTO> Create(UserCreateDTO dto);
        Task<UserViewDTO> Update(UserUpdateDTO dto);
        Task<bool> Delete(Guid id);
        Task<UserViewDTO?> GetById(Guid id);
        Task<UserViewDTO?> GetByUserName(string userName);
        Task<IEnumerable<UserViewDTO>> GetAll();

        Task<bool> Follow(UserFollowDTO dto);
    }
}
