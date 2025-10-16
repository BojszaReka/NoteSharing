using class_library.DTO;

namespace web_api.Lib.Services.Interfaces
{
    public interface IUserSubjectManagerService
    {
        Task<bool> AddAsync(UserSubjectDTO dto);
        Task<bool> RemoveAsync(UserSubjectDTO dto);
        Task<IEnumerable<SubjectViewDTO>> GetByUserAsync(Guid userId);
    }
}
