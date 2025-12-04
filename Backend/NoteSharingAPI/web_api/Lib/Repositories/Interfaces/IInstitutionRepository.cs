using class_library.DTO;

namespace web_api.Lib.Repositories.Interfaces
{
    public interface IInstitutionRepository
    {
        Task<InstitutionViewDTO> Create(InstitutionCreateDTO dto);
        Task<InstitutionViewDTO> Update(InstitutionViewDTO dto);
        Task<bool> Delete(Guid id);
        Task<InstitutionViewDTO?> GetById(Guid id);
        Task<IEnumerable<InstitutionViewDTO>> GetAll();
    }
}
