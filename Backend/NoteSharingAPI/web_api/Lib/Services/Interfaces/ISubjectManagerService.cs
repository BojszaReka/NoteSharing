using class_library.DTO;

namespace web_api.Lib.ManagerServices.Interfaces
{
    public interface ISubjectManagerService
    {
        Task<SubjectViewDTO> CreateAsync(SubjectCreateDTO dto);
        Task<SubjectViewDTO> UpdateAsync(SubjectViewDTO dto);
        Task<bool> DeleteAsync(Guid id);
        Task<SubjectViewDTO?> GetByIdAsync(Guid id);
        Task<IEnumerable<SubjectViewDTO>> GetAllAsync();
    }
}
