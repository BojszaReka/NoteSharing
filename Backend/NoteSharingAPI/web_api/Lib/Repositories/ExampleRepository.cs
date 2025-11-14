using web_api.Lib.Repositories.Interfaces;
using web_api.Lib.Services.Interfaces;

namespace web_api.Lib.Repositories
{
	public class ExampleRepository : IExampleRepository
	{
		private readonly IServiceScopeFactory _serviceScopeFactory;

		public ExampleRepository(IServiceScopeFactory serviceScopeFactory)
		{
			_serviceScopeFactory = serviceScopeFactory;
		}

		//public async Task<ReturnType> MethodNameAsync(ParameterType parameter)
		//{
		//	using var scope = _serviceScopeFactory.CreateScope();
		//	var service = scope.ServiceProvider.GetRequiredService<IExampleService>();
		//	return await service.method(parameter);
		//}

		//Dont forget to add to Unitofwork!!
	}
}
