using class_library.DTO;

namespace web_api.Lib.Services.Interfaces
{
    public interface IInstitutionManagerService
    {
        Task<InstitutionViewDTO> CreateAsync(InstitutionCreateDTO dto);
        Task<InstitutionViewDTO> UpdateAsync(InstitutionViewDTO dto);
        Task<bool> DeleteAsync(Guid id);
        Task<InstitutionViewDTO?> GetByIdAsync(Guid id);
        Task<IEnumerable<InstitutionViewDTO>> GetAllAsync();
    }
}
