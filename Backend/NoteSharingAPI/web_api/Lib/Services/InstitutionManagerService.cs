using class_library.DTO;
using web_api.Lib.ManagerServices.Interfaces;

namespace web_api.Lib.ManagerServices
{
    public class InstitutionManagerService : IInstitutionManagerService
    {
        public Task<InstitutionViewDTO> CreateAsync(InstitutionCreateDTO dto)
        {
            throw new NotImplementedException();
        }

        public Task<InstitutionViewDTO> UpdateAsync(InstitutionViewDTO dto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<InstitutionViewDTO?> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<InstitutionViewDTO>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
