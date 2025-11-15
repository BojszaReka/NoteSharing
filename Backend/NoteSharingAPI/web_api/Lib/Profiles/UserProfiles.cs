using Mapster;
using class_library.DTO;
using class_library.Models;

namespace web_api.Lib.Profiles
{
    public class UserProfiles : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<User, UserViewDTO>();

            config.NewConfig<UserCreateDTO, User>();
            config.NewConfig<UserUpdateDTO, User>();

            config.NewConfig<User, StudentViewDTO>();
        }
    }
}
