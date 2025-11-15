using class_library.DTO;
using class_library.Enums;
using class_library.Models;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using web_api.Lib.Database;
using web_api.Lib.Services.Interfaces;

namespace web_api.Lib.Services
{
    public class StudentManagerService : IStudentManagerService
    {
        private readonly db_context _dbContext;
        private readonly IDistributedCache _cache;

        public StudentManagerService(db_context dbContext, IDistributedCache cache)
        {
            _dbContext = dbContext;
            _cache = cache;
        }

        public async Task<IEnumerable<StudentViewDTO>> GetAllAsync()
        {
            const string cacheKey = "students_all";
            var cached = await _cache.GetStringAsync(cacheKey);
            if (!string.IsNullOrEmpty(cached))
                return JsonConvert.DeserializeObject<IEnumerable<StudentViewDTO>>(cached) ?? Enumerable.Empty<StudentViewDTO>();

            var users = await _dbContext.Users
                .Where(u => u.UserType == EUserType.Student && u.Enabled)
                .ToListAsync();

            var result = users.Adapt<IEnumerable<StudentViewDTO>>();

            await _cache.SetStringAsync(cacheKey, JsonConvert.SerializeObject(result));

            return result;
        }

        public async Task<StudentViewDTO?> GetByIdAsync(Guid id)
        {
            var cacheKey = $"student_{id}";
            var cached = await _cache.GetStringAsync(cacheKey);
            if (!string.IsNullOrEmpty(cached))
                return JsonConvert.DeserializeObject<StudentViewDTO>(cached);

            var user = await _dbContext.Users
                .FirstOrDefaultAsync(u => u.ID == id && u.UserType == EUserType.Student && u.Enabled);

            if (user == null)
                return null;

            var dto = user.Adapt<StudentViewDTO>();

            await _cache.SetStringAsync(cacheKey, JsonConvert.SerializeObject(dto));

            return dto;
        }

        public async Task<IEnumerable<StudentViewDTO>> GetByInstitutionAsync(Guid institutionId)
        {
            var cacheKey = $"students_institution_{institutionId}";
            var cached = await _cache.GetStringAsync(cacheKey);
            if (!string.IsNullOrEmpty(cached))
                return JsonConvert.DeserializeObject<IEnumerable<StudentViewDTO>>(cached) ?? Enumerable.Empty<StudentViewDTO>();

            var users = await _dbContext.Users
                .Where(u => u.UserType == EUserType.Student &&
                            u.Enabled &&
                            u.InstitutionID == institutionId)
                .ToListAsync();

            var result = users.Adapt<IEnumerable<StudentViewDTO>>();

            await _cache.SetStringAsync(cacheKey, JsonConvert.SerializeObject(result));

            return result;
        }

        public async Task<IEnumerable<StudentViewDTO>> GetBySubjectAsync(Guid subjectId)
        {
            var cacheKey = $"students_subject_{subjectId}";
            var cached = await _cache.GetStringAsync(cacheKey);
            if (!string.IsNullOrEmpty(cached))
                return JsonConvert.DeserializeObject<IEnumerable<StudentViewDTO>>(cached) ?? Enumerable.Empty<StudentViewDTO>();

            var query =
                from us in _dbContext.UserSubjects
                join u in _dbContext.Users on us.UserID equals u.ID
                where us.SubjectID == subjectId &&
                      u.UserType == EUserType.Student &&
                      u.Enabled
                select u;

            var users = await query.Distinct().ToListAsync();

            var result = users.Adapt<IEnumerable<StudentViewDTO>>();

            await _cache.SetStringAsync(cacheKey, JsonConvert.SerializeObject(result));

            return result;
        }
    }
}
