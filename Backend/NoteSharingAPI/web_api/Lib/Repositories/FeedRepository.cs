using Microsoft.Extensions.DependencyInjection;
using web_api.Lib.Repositories.Interfaces;
using web_api.Lib.Services.Interfaces;

namespace web_api.Lib.Repositories
{
	public class FeedRepository : IFeedRepository
	{
		private IServiceScopeFactory _serviceScopeFactory;

		public FeedRepository(IServiceScopeFactory scopeFactory)
		{
			_serviceScopeFactory = scopeFactory;
		}

		public async Task<object?> GetFeedForUser(Guid userId)
		{
			using var scope = _serviceScopeFactory.CreateScope();
			var service = scope.ServiceProvider.GetRequiredService<IFeedManagerService>();
			return await service.GetFeedForUser(userId);
		}
	}
}
