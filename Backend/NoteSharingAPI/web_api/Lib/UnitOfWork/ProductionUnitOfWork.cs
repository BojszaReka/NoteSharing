using web_api.Lib.Repositories;
using web_api.Lib.Repositories.Interfaces;

namespace web_api.Lib.UnitOfWork
{
	public class ProductionUnitOfWork : IUnitOfWork
	{
		public IExampleRepository ExampleRepository { get; }

		public ProductionUnitOfWork(IServiceScopeFactory scopeFactory)
		{
			ExampleRepository = new ExampleRepository(scopeFactory);
		}

	}
}
