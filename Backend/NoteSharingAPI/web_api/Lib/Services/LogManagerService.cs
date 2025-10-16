using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
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

		private async Task<IQueryable<Log>> querryLogs()
		{
			var cachedData = await _cache.GetStringAsync("log");
			if (!string.IsNullOrEmpty(cachedData))
			{
				var data = JsonConvert.DeserializeObject<List<Log>>(cachedData);
				return data.AsQueryable();
			}
			var dataFromDb = await _dbContext.Logs.OrderBy(c => c.ID).ToListAsync();
			var cacheOptions = new DistributedCacheEntryOptions
			{
				AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10),
				SlidingExpiration = TimeSpan.FromMinutes(5)
			};

			var serializedData = JsonConvert.SerializeObject(dataFromDb);
			await _cache.SetStringAsync("logs", serializedData, cacheOptions);
			return dataFromDb.AsQueryable();
		}

		public async Task<Log> AddLog(Log log)
		{
			using var transaction = _dbContext.Database.BeginTransaction();
			try
			{
				log.ID = Guid.NewGuid();
				log.Date = DateTime.UtcNow;
				 _dbContext.Logs.Add(log);
				 _dbContext.SaveChanges();
				await _cache.RemoveAsync("logs");
				transaction.Commit();
				return await Task.FromResult(log);
			}
			catch (Exception ex)
			{
				transaction.Rollback();
				throw new Exception("Failed to add log", ex);
			}
			finally
			{
				transaction.Dispose();
			}
		}

		public async Task<Log> AddLog(Guid id)
		{
			using var transaction = _dbContext.Database.BeginTransaction();
			try
			{
				Log l = new Log();
				l.ID = id;
				_dbContext.Logs.Add(l);
				_dbContext.SaveChanges();
				await _cache.RemoveAsync("logs");
				transaction.Commit();
				return await Task.FromResult(l);
			}
			catch (Exception ex)
			{
				transaction.Rollback();
				throw new Exception("Failed to add log", ex);
			} finally
			{
				transaction.Dispose();
			}
		}

		public async Task<IEnumerable<Log>> GetAll()
		{
			var logs = await querryLogs();
			if (logs == null)
			{
				throw new Exception("No logs found");
			}
			return logs.AsEnumerable();
		}

		public async Task<Log> GetLog(Guid id)
		{
			var logs = await querryLogs();
			if (logs == null)
			{
				throw new Exception("No logs found");
			}
			var log = logs.FirstOrDefault(l => l.ID == id);
			if (log == null)
			{
				throw new Exception("Log not found");
			}
			return log;
		}

		public async Task<IEnumerable<Log>> GetLogsBySeverity(ESeverity severity)
		{
			var logs = await querryLogs();
			if (logs == null)
			{
				throw new Exception("No logs found");
			}
			var filteredLogs = logs.Where(l => l.Severity == severity);
			return filteredLogs.AsEnumerable();
		}

		public async Task<IEnumerable<Log>> GetLogsByUser(string userId)
		{
			var logs = await querryLogs();
			if (logs == null)
			{
				throw new Exception("No logs found");
			}
			var filteredLogs = logs.Where(l => l.UserId == userId);
			return filteredLogs.AsEnumerable();

		}

		public async Task<Log> UpdateLog(Log log)
		{
			var logs = await querryLogs();
			if (logs == null)
			{
				throw new Exception("No logs found");
			}
			var existingLog = logs.FirstOrDefault(l => l.ID == log.ID);
			if (existingLog == null)
			{
				throw new Exception("Log not found");
			}
			using var transaction = _dbContext.Database.BeginTransaction();
			try
			{
				_dbContext.Logs.Update(log);
				_dbContext.SaveChanges();
				await _cache.RemoveAsync("logs");
				transaction.Commit();
				return await Task.FromResult(log);
			}
			catch (Exception ex)
			{
				transaction.Rollback();
				throw new Exception("Failed to update log", ex);
			}
			finally
			{
				transaction.Dispose();
			}
		}
	}
}
