using System;
using class_library.Enums;

namespace class_library.DTO
{
    public class UserViewDTO
    {
        public Guid ID { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public EUserType UserType { get; set; }
        public Guid PreferenceID { get; set; }
        public Guid InstitutionID { get; set; }
	}
}
