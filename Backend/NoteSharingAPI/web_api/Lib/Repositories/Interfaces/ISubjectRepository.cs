using class_library.DTO;

namespace web_api.Lib.Repositories.Interfaces
{
    public interface ISubjectRepository
    {
        Task<SubjectViewDTO> Create(SubjectCreateDTO dto);
        Task<SubjectViewDTO> Update(SubjectViewDTO dto);
        Task<bool> Delete(Guid id);
        Task<SubjectViewDTO?> GetById(Guid id);
        Task<IEnumerable<SubjectViewDTO>> GetAll();
    }
}
