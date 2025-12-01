using class_library.DTO;

namespace web_api.Lib.Repositories.Interfaces
{
    public interface IStudentRepository
    {
        Task<IEnumerable<StudentViewDTO>> GetAll();
        Task<StudentViewDTO?> GetById(Guid id);
        Task<IEnumerable<StudentViewDTO>> GetByInstitution(Guid institutionId);
        Task<IEnumerable<StudentViewDTO>> GetBySubject(Guid subjectId);
    }
}
