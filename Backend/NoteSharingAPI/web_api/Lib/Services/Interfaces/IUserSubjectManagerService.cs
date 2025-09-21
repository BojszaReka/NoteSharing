using class_library.DTO;

namespace web_api.Lib.ManagerServices.Interfaces
{
    public interface IUserSubjectManagerService
    {
        Task<bool> AddAsync(UserSubjectDTO dto);
        Task<bool> RemoveAsync(UserSubjectDTO dto);
        Task<IEnumerable<UserSubjectDTO>> GetByUserAsync(Guid userId);
        Task<IEnumerable<UserSubjectDTO>> GetBySubjectAsync(Guid subjectId);
    }
}
