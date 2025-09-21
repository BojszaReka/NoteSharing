using class_library.DTO;
using web_api.Lib.ManagerServices.Interfaces;

namespace web_api.Lib.ManagerServices
{
    public class PreferenceManagerService : IPreferenceManagerService
    {
        public Task<PreferenceViewDTO> CreateAsync(PreferenceViewDTO dto) => throw new NotImplementedException();
        public Task<PreferenceViewDTO> UpdateAsync(PreferenceViewDTO dto) => throw new NotImplementedException();
        public Task<bool> DeleteAsync(Guid id) => throw new NotImplementedException();
        public Task<PreferenceViewDTO?> GetByIdAsync(Guid id) => throw new NotImplementedException();
    }
}
