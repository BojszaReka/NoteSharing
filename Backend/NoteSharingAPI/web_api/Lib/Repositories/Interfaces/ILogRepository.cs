namespace web_api.Lib.Repositories.Interfaces
{
	public interface ILogRepository
	{
		Task<IEnumerable<Log>> GetAll();
		Task<IEnumerable<Log>> GetLogsBySeverity(ESeverity severity);
		Task<IEnumerable<Log>> GetLogsByUser(string UserId);
		Task<Log> GetLog(Guid id);
		Task<Log> AddLog(Log log);
		Task<Log> UpdateLog(Log log);
		Task<Log> DeleteLog(Guid id);

	}
}
