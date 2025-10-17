using class_library.Models;
using web_api.Lib.Repositories.Interfaces;
using web_api.Lib.Services.Interfaces;

namespace web_api.Lib.Repositories
{
	public class LogRepository : ILogRepository
	{
		private readonly IServiceScopeFactory _serviceScopeFactory;

		public LogRepository(IServiceScopeFactory serviceScopeFactory)
		{
			_serviceScopeFactory = serviceScopeFactory;
		}
		public async Task<Log> AddLog(Log log)
		{
			using var scope = _serviceScopeFactory.CreateScope();
			var service = scope.ServiceProvider.GetRequiredService<ILogManagerService>();
			return await service.AddLog(log);
		}

		public async Task<Log> DeleteLog(Guid id)
		{
			using var scope = _serviceScopeFactory.CreateScope();
			var service = scope.ServiceProvider.GetRequiredService<ILogManagerService>();
			return await service.AddLog(id);
		}

		public async Task<IEnumerable<Log>> GetAll()
		{
			using var scope = _serviceScopeFactory.CreateScope();
			var service = scope.ServiceProvider.GetRequiredService<ILogManagerService>();
			return await service.GetAll();
		}

		public async Task<Log> GetLog(Guid id)
		{
			using var scope = _serviceScopeFactory.CreateScope();
			var service = scope.ServiceProvider.GetRequiredService<ILogManagerService>();
			return await service.GetLog(id);
		}

		public async Task<IEnumerable<Log>> GetLogsBySeverity(ESeverity severity)
		{
			using var scope = _serviceScopeFactory.CreateScope();
			var service = scope.ServiceProvider.GetRequiredService<ILogManagerService>();
			return await service.GetLogsBySeverity(severity);
		}

		public async Task<IEnumerable<Log>> GetLogsByUser(string UserId)
		{
			using var scope = _serviceScopeFactory.CreateScope();
			var service = scope.ServiceProvider.GetRequiredService<ILogManagerService>();
			return await service.GetLogsByUser(UserId);
		}

		public async Task<Log> UpdateLog(Log log)
		{
			using var scope = _serviceScopeFactory.CreateScope();
			var service = scope.ServiceProvider.GetRequiredService<ILogManagerService>();
			return await service.UpdateLog(log);
		}
	}
}
