using System;

namespace class_library.DTO
{
    public class StudentViewDTO : UserViewDTO
    {
        public Guid InstitutionID { get; set; }
        public string Grade { get; set; }
    }
}
