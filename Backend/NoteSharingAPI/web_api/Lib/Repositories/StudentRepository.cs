using class_library.DTO;
using Microsoft.Extensions.DependencyInjection;
using web_api.Lib.Repositories.Interfaces;
using web_api.Lib.Services.Interfaces;

namespace web_api.Lib.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public StudentRepository(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        public async Task<IEnumerable<StudentViewDTO>> GetAll()
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var service = scope.ServiceProvider.GetRequiredService<IStudentManagerService>();
            return await service.GetAllAsync();
        }

        public async Task<StudentViewDTO?> GetById(Guid id)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var service = scope.ServiceProvider.GetRequiredService<IStudentManagerService>();
            return await service.GetByIdAsync(id);
        }

        public async Task<IEnumerable<StudentViewDTO>> GetByInstitution(Guid institutionId)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var service = scope.ServiceProvider.GetRequiredService<IStudentManagerService>();
            return await service.GetByInstitutionAsync(institutionId);
        }

        public async Task<IEnumerable<StudentViewDTO>> GetBySubject(Guid subjectId)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var service = scope.ServiceProvider.GetRequiredService<IStudentManagerService>();
            return await service.GetBySubjectAsync(subjectId);
        }
    }
}
