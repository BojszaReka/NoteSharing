using class_library.DTO;
using class_library.Enums;
using class_library.Models;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using web_api.Lib.Database;
using web_api.Lib.Services.Interfaces;

namespace web_api.Lib.Services
{
    public class StudentManagerService : IStudentManagerService
    {
        private readonly db_context _dbContext;
        private readonly IDistributedCache _cache;
        private readonly IServiceScopeFactory _scopeFactory;

        public StudentManagerService(db_context dbContext, IDistributedCache cache, IServiceScopeFactory scopeFactory)
        {
            _dbContext = dbContext;
            _cache = cache;
            _scopeFactory = scopeFactory;
        }

        private async Task<IQueryable<User>> querryStudents()
        {
            var cachedData = await _cache.GetStringAsync("students");
            if (!string.IsNullOrEmpty(cachedData))
            {
                var data = JsonConvert.DeserializeObject<List<User>>(cachedData);
                return data.AsQueryable();
            }

            var dataFromDb = await _dbContext.Users
                .Where(u => u.UserType == EUserType.Student)
                .OrderBy(u => u.ID)
                .ToListAsync();

            var cacheOptions = new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10),
                SlidingExpiration = TimeSpan.FromMinutes(5)
            };

            var serializedData = JsonConvert.SerializeObject(dataFromDb);
            await _cache.SetStringAsync("students", serializedData, cacheOptions);

            return dataFromDb.AsQueryable();
        }

        public async Task<IEnumerable<StudentViewDTO>> GetAllAsync()
        {
            try
            {
                var students = await querryStudents();
                if (students == null || !students.Any())
                    throw new KeyNotFoundException("No students found.");

                var enabledStudents = students.Where(s => s.Enabled);
                return enabledStudents.Select(s => s.Adapt<StudentViewDTO>()).ToList();
            }
            catch (Exception ex)
            {
                await Log(severity: ESeverity.Error, message: "GetAll students unsuccessful: " + ex.Message);
                throw new Exception("Error getting students: " + ex.Message);
            }
            finally
            {
            }
        }

        public async Task<StudentViewDTO?> GetByIdAsync(Guid id)
        {
            try
            {
                var students = await querryStudents();
                var student = students.FirstOrDefault(s => s.ID == id);
                if (student == null)
                    throw new KeyNotFoundException($"Student with ID {id} not found.");
                if (!student.Enabled)
                    throw new KeyNotFoundException($"Student with ID {id} is deleted.");

                return student.Adapt<StudentViewDTO>();
            }
            catch (Exception ex)
            {
                await Log(UserId: id.ToString(), severity: ESeverity.Error, message: "Get student by id unsuccessful: " + ex.Message);
                throw new Exception("Error retrieving student: " + ex.Message);
            }
            finally
            {
            }
        }

        public async Task<IEnumerable<StudentViewDTO>> GetByInstitutionAsync(Guid institutionId)
        {
            try
            {
                var students = await querryStudents();
                var result = students
                    .Where(s => s.Enabled && s.InstitutionID == institutionId)
                    .Select(s => s.Adapt<StudentViewDTO>())
                    .ToList();

                if (!result.Any())
                    throw new KeyNotFoundException($"No students found for institution {institutionId}.");

                return result;
            }
            catch (Exception ex)
            {
                await Log(severity: ESeverity.Error, message: "Get students by institution unsuccessful: " + ex.Message);
                throw new Exception("Error retrieving students by institution: " + ex.Message);
            }
            finally
            {
            }
        }

        public async Task<IEnumerable<StudentViewDTO>> GetBySubjectAsync(Guid subjectId)
        {
            try
            {
                var students = await querryStudents();

                var studentIds = await _dbContext.UserSubjects
                    .Where(us => us.SubjectID == subjectId)
                    .Select(us => us.UserID)
                    .Distinct()
                    .ToListAsync();

                var filteredStudents = students
                    .Where(s => s.Enabled && studentIds.Contains(s.ID))
                    .ToList();

                if (!filteredStudents.Any())
                    throw new KeyNotFoundException($"No students found for subject {subjectId}.");

                return filteredStudents.Select(s => s.Adapt<StudentViewDTO>()).ToList();
            }
            catch (Exception ex)
            {
                await Log(severity: ESeverity.Error, message: "Get students by subject unsuccessful: " + ex.Message);
                throw new Exception("Error retrieving students by subject: " + ex.Message);
            }
            finally
            {
            }
        }

        private async Task Log(string UserId = "System", ESeverity severity = ESeverity.Information, string message = "")
        {
            var scope = _scopeFactory.CreateScope();
            var _logManager = scope.ServiceProvider.GetRequiredService<ILogManagerService>();
            Log log = new Log()
            {
                UserId = UserId,
                Severity = severity,
                Message = message
            };
            var response = await _logManager.AddLog(log);
            scope.Dispose();
            if (response != null)
            {
                throw new Exception($"Couldn't log activity: '{message}'");
            }
        }
    }
}
