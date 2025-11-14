using Mapster;
using class_library.DTO;
using class_library.Models;

namespace web_api.Lib.Profiles
{
    public class InstitutionProfiles : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Institution, InstitutionViewDTO>();
            config.NewConfig<InstitutionCreateDTO, Institution>();
        }
    }
}
