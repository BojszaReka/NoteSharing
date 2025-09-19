namespace web_api.Lib.UnitOfWork
{
	public static class ServiceCollection
	{
		public static void AddLocalServices(this IServiceCollection services)
		{
			services.AddScoped<IUnitOfWork, ProductionUnitOfWork>();

			// Add other services here as needed
			// services.AddScoped<IOtherService, OtherService>();
		}
	}
}
