
namespace web_api.Lib.Services.Interfaces
{
	public interface IFeedManagerService
	{
		Task<object?> GetFeedForUser(Guid userId);
	}
}
