using class_library.DTO;

namespace web_api.Lib.Services.Interfaces
{
    public interface IPreferenceManagerService
    {
        Task<PreferenceViewDTO> CreateAsync(PreferenceViewDTO dto);
        Task<PreferenceViewDTO> UpdateAsync(PreferenceViewDTO dto);
        Task<bool> DeleteAsync(Guid id);
        Task<PreferenceViewDTO?> GetByIdAsync(Guid id);
    }
}
