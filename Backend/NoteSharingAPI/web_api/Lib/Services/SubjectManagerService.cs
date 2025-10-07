using class_library.DTO;
using web_api.Lib.Services.Interfaces;

namespace web_api.Lib.Services
{
    public class SubjectManagerService : ISubjectManagerService
    {
        public Task<SubjectViewDTO> CreateAsync(SubjectCreateDTO dto)
        {
            throw new NotImplementedException();
        }

        public Task<SubjectViewDTO> UpdateAsync(SubjectViewDTO dto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<SubjectViewDTO?> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<SubjectViewDTO>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
