using Mapster;
using class_library.DTO;
using class_library.Models;

namespace web_api.Lib.Profiles
{
    public class RelationProfiles : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<UserSubject, UserSubjectDTO>();
            config.NewConfig<UserFollow, UserFollowDTO>();
        }
    }
}
