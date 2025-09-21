using Mapster;
using class_library.DTO;
using class_library.Models;

namespace web_api.Lib.Profiles
{
	public class ExampleProfile : IRegister
	{
		public void Register(TypeAdapterConfig config)
		{
			// Example mapping configuration
			// config.NewConfig<SourceType, DestinationType>();
		}
	}
}
