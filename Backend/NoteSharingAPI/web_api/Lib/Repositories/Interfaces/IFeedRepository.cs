
namespace web_api.Lib.Repositories.Interfaces
{
	public interface IFeedRepository
	{
		Task<object?> GetFeedForUser(Guid userId);
	}
}
