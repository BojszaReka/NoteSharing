using Microsoft.Extensions.Caching.Distributed;
using web_api.Lib.Database;
using web_api.Lib.Services.Interfaces;

namespace web_api.Lib.Services
{
	public class LogManagerService : ILogManagerService
	{
		private readonly db_context _dbContext;
		private readonly IDistributedCache _cache;
		public LogManagerService(db_context dbContext, IDistributedCache cache)
		{
			_dbContext = dbContext;
			_cache = cache;
		}

		public Task<Log> AddLog(Log log)
		{
			throw new NotImplementedException();
		}

		public Task<Log> AddLog(Guid id)
		{
			throw new NotImplementedException();
		}

		public Task<IEnumerable<Log>> GetAll()
		{
			throw new NotImplementedException();
		}

		public Task<Log> GetLog(Guid id)
		{
			throw new NotImplementedException();
		}

		public Task<IEnumerable<Log>> GetLogsBySeverity(ESeverity severity)
		{
			throw new NotImplementedException();
		}

		public Task<IEnumerable<Log>> GetLogsByUser(string userId)
		{
			throw new NotImplementedException();
		}

		public Task<Log> UpdateLog(Log log)
		{
			throw new NotImplementedException();
		}
	}
}
