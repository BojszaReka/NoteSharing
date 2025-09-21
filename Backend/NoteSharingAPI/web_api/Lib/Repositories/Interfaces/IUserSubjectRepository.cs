using class_library.DTO;

namespace web_api.Lib.Repositories.Interfaces
{
    public interface IUserSubjectRepository
    {
        Task<bool> Add(UserSubjectDTO dto);
        Task<bool> Remove(UserSubjectDTO dto);
        Task<IEnumerable<UserSubjectDTO>> GetByUser(Guid userId);
        Task<IEnumerable<UserSubjectDTO>> GetBySubject(Guid subjectId);
    }
}
