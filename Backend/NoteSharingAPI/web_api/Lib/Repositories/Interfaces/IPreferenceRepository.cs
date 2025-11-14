using class_library.DTO;

namespace web_api.Lib.Repositories.Interfaces
{
    public interface IPreferenceRepository
    {
        Task<PreferenceViewDTO> Create(PreferenceViewDTO dto);
        Task<PreferenceViewDTO> Update(PreferenceViewDTO dto);
        Task<bool> Delete(Guid id);
        Task<PreferenceViewDTO?> GetById(Guid id);
    }
}
