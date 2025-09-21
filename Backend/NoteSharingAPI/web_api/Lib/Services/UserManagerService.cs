using class_library.DTO;
using web_api.Lib.ManagerServices.Interfaces;

namespace web_api.Lib.ManagerServices
{
    public class UserManagerService : IUserManagerService
    {
        public Task<UserViewDTO> CreateAsync(UserCreateDTO dto) => throw new NotImplementedException();
        public Task<UserViewDTO> UpdateAsync(UserUpdateDTO dto) => throw new NotImplementedException();
        public Task<bool> DeleteAsync(Guid id) => throw new NotImplementedException();
        public Task<UserViewDTO?> GetByIdAsync(Guid id) => throw new NotImplementedException();
        public Task<UserViewDTO?> GetByUserNameAsync(string userName) => throw new NotImplementedException();
        public Task<IEnumerable<UserViewDTO>> GetAllAsync() => throw new NotImplementedException();
        public Task<bool> FollowAsync(UserFollowDTO dto) => throw new NotImplementedException();
    }
}
