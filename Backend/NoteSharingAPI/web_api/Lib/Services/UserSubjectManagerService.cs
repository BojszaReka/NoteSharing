using class_library.DTO;
using web_api.Lib.Services.Interfaces;

namespace web_api.Lib.Services
{
    public class UserSubjectManagerService : IUserSubjectManagerService
    {
        public Task<bool> AddAsync(UserSubjectDTO dto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveAsync(UserSubjectDTO dto)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserSubjectDTO>> GetByUserAsync(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserSubjectDTO>> GetBySubjectAsync(Guid subjectId)
        {
            throw new NotImplementedException();
        }
    }
}
