using Mapster;
using class_library.DTO;
using class_library.Models;

namespace web_api.Lib.Profiles
{
    public class SubjectProfiles : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Subject, SubjectViewDTO>();
            config.NewConfig<SubjectCreateDTO, Subject>();
        }
    }
}
