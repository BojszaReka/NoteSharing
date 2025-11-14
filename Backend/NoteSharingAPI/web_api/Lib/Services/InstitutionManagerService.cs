using class_library.DTO;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using web_api.Lib.Database;
using web_api.Lib.Services.Interfaces;

namespace web_api.Lib.Services
{
	/// <summary>
	/// Provides functionality for managing institutions including creation, update, deletion, and retrieval.
	/// </summary>
	public class InstitutionManagerService : IInstitutionManagerService
    {
		private readonly db_context _dbContext;
		private readonly IDistributedCache _cache;
		private readonly IServiceScopeFactory _scopeFactory = null!;

		/// <summary>
		/// Initializes a new instance of the <see cref="InstitutionManagerService"/> class.
		/// </summary>
		/// <param name="dbContext">Database context for data operations.</param>
		/// <param name="cache">Distributed cache instance for caching institution data.</param>
		/// <param name="scopeFactory">Service scope factory for creating service scopes.</param>
		public InstitutionManagerService(db_context dbContext, IDistributedCache cache, IServiceScopeFactory scopeFactory)
		{
			_dbContext = dbContext;
			_cache = cache;
			_scopeFactory = scopeFactory;
		}

		private async Task<IQueryable<Institution>> querryInstitutions()
		{
			var cachedData = await _cache.GetStringAsync("institutions");
			if (!string.IsNullOrEmpty(cachedData))
			{
				var data = JsonConvert.DeserializeObject<List<Institution>>(cachedData);
				return data.AsQueryable();
			}
			var dataFromDb = await _dbContext.Institutions.OrderBy(c => c.ID).ToListAsync();
			var cacheOptions = new DistributedCacheEntryOptions
			{
				AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10),
				SlidingExpiration = TimeSpan.FromMinutes(5)
			};

			var serializedData = JsonConvert.SerializeObject(dataFromDb);
			await _cache.SetStringAsync("institutions", serializedData, cacheOptions);
			return dataFromDb.AsQueryable();
		}

		/// <summary>
		/// Creates a new institution record in the database.
		/// </summary>
		/// <param name="dto">The data transfer object containing institution creation details.</param>
		/// <returns>A task that represents the asynchronous operation. The task result contains the created <see cref="InstitutionViewDTO"/>.</returns>
		/// <exception cref="Exception">Thrown when an institution with the same name already exists or when the operation fails.</exception>
		public async Task<InstitutionViewDTO> CreateAsync(InstitutionCreateDTO dto)
		{
			using var transaction = await _dbContext.Database.BeginTransactionAsync();
			try
			{
				var intitutions = await querryInstitutions();
				if (intitutions.Any(i => i.Name.ToLower() == dto.Name.ToLower()))
				{
					throw new Exception("Institution with this name already exists");
				}
				var institution = new Institution
				{
					ID = Guid.NewGuid(),
					Name = dto.Name
				};
				_dbContext.Institutions.Add(institution);
				await _dbContext.SaveChangesAsync();
				await _cache.RemoveAsync("institutions");
				await transaction.CommitAsync();
				await Log(severity: ESeverity.Information, message: $"Institution '{institution.Name}' created with ID: {institution.ID}");
				return new InstitutionViewDTO
				{
					ID = institution.ID,
					Name = institution.Name
				};
			}
			catch (Exception ex)
			{
				await transaction.RollbackAsync();
				await Log(severity: ESeverity.Error, message: "Institution operation unsuccessful: " + ex.Message);
				throw new Exception("Error processing institution: " + ex.Message);
			}
			finally
			{
				await transaction.DisposeAsync();
			}
		}

		/// <summary>
		/// Updates an existing institution with the provided data.
		/// </summary>
		/// <param name="dto">The institution data to be updated.</param>
		/// <returns>A task that represents the asynchronous operation. The task result contains the updated <see cref="InstitutionViewDTO"/>.</returns>
		/// <exception cref="Exception">Thrown when the institution is not found, inactive, or the operation fails.</exception>
		public async Task<InstitutionViewDTO> UpdateAsync(InstitutionViewDTO dto)
        {
            using var transaction = await _dbContext.Database.BeginTransactionAsync();
            try
            {
                var institutions = await querryInstitutions();
                var institution = institutions.FirstOrDefault(i => i.ID == dto.ID);
                if (institution == null)
                {
                    throw new Exception("Institution not found");
                }
				if (institution.IsActive == false)
				{
					throw new Exception("Cannot update an inactive institution");
				}
				institution.Name = dto.Name;
                _dbContext.Institutions.Update(institution);
                await _dbContext.SaveChangesAsync();
                await _cache.RemoveAsync("institutions");
                await transaction.CommitAsync();
                await Log(severity: ESeverity.Information, message: $"Institution '{institution.Name}' with ID: {institution.ID} updated");
                return new InstitutionViewDTO
                {
                    ID = institution.ID,
                    Name = institution.Name
                };
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                await Log(severity: ESeverity.Error, message: "Institution operation unsuccessful: " + ex.Message);
                throw new Exception("Error processing institution: " + ex.Message);
            }
            finally
            {
                await transaction.DisposeAsync();
            }
        }

		/// <summary>
		/// Deletes (sets inactive) an institution by its unique identifier.
		/// </summary>
		/// <param name="id">The unique identifier of the institution to delete.</param>
		/// <returns>A task that represents the asynchronous operation. The task result is <c>true</c> if the deletion succeeds.</returns>
		/// <exception cref="Exception">Thrown when the institution is not found or when the operation fails.</exception>
		public async Task<bool> DeleteAsync(Guid id)
        {
            using var transaction = await _dbContext.Database.BeginTransactionAsync();
            try
            {
                var institutions = await querryInstitutions();
                var institution = institutions.FirstOrDefault(i => i.ID == id);
                if (institution == null)
                {
                    throw new Exception("Institution not found");
                }
                institution.IsActive = false;
                _dbContext.Institutions.Update(institution);
                await _dbContext.SaveChangesAsync();
                await _cache.RemoveAsync("institutions");
                await transaction.CommitAsync();
                await Log(severity: ESeverity.Information, message: $"Institution '{institution.Name}' with ID: {institution.ID} deleted (set inactive)");
                return true;
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                await Log(severity: ESeverity.Error, message: "Institution delete operation unsuccessful: " + ex.Message);
                throw new Exception("Error deleting institution: " + ex.Message);
            }
            finally
            {
                await transaction.DisposeAsync();
            }
        }

		/// <summary>
		/// Retrieves a single active institution by its unique identifier.
		/// </summary>
		/// <param name="id">The unique identifier of the institution to retrieve.</param>
		/// <returns>A task that represents the asynchronous operation. The task result contains the <see cref="InstitutionViewDTO"/> of the institution.</returns>
		/// <exception cref="Exception">Thrown when the institution is not found.</exception>
		public async Task<InstitutionViewDTO?> GetByIdAsync(Guid id)
        {
            var institutions = await querryInstitutions();
			var institution = institutions.FirstOrDefault(i => i.ID == id && i.IsActive);
			if (institution == null)
			{
				throw new Exception("Institution not found");
			}
			return institution.Adapt<InstitutionViewDTO>();

		}

		/// <summary>
		/// Retrieves all active institutions from the database or cache.
		/// </summary>
		/// <returns>A task that represents the asynchronous operation. The task result contains a collection of <see cref="InstitutionViewDTO"/>.</returns>
		/// <exception cref="Exception">Thrown when no institutions are found.</exception>
		public async Task<IEnumerable<InstitutionViewDTO>> GetAllAsync()
        {
            var institutions = await querryInstitutions();
			if (!institutions.Any(i => i.IsActive))
			{
				throw new Exception("No institutions found");
			}
			return institutions.Where(i => i.IsActive).OrderBy(i => i.Name).Select(i => new InstitutionViewDTO
			{
				ID = i.ID,
				Name = i.Name
			}).ToList();
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
