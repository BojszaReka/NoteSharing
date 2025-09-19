
using web_api.Lib.Repositories.Interfaces;

namespace web_api.Lib.UnitOfWork
{
	public interface IUnitOfWork
	{
		IExampleRepository ExampleRepository { get; }
	}
}
