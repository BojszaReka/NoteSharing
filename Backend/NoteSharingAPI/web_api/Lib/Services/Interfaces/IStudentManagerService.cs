using class_library.DTO;

namespace web_api.Lib.Services.Interfaces
{
    public interface IStudentManagerService
    {
        Task<IEnumerable<StudentViewDTO>> GetAllAsync();
        Task<StudentViewDTO?> GetByIdAsync(Guid id);
        Task<IEnumerable<StudentViewDTO>> GetByInstitutionAsync(Guid institutionId);
        Task<IEnumerable<StudentViewDTO>> GetBySubjectAsync(Guid subjectId);
    }
}
