



namespace web_api.Lib.Services.Interfaces
{
	public interface ILogManagerService
	{
		Task<Log> AddLog(Log log);
		Task<Log> AddLog(Guid id);
		Task<IEnumerable<Log>> GetAll();
		Task<Log> GetLog(Guid id);
		Task<IEnumerable<Log>> GetLogsBySeverity(ESeverity severity);
		Task<IEnumerable<Log>> GetLogsByUser(string userId);
		Task<Log> UpdateLog(Log log);
	}
}
