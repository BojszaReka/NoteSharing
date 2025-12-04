using System;

namespace class_library.DTO
{
    public class SubjectViewDTO
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string NeptunCode { get; set; }
        public Guid InstitutionID { get; set; }
        public Guid? InstructorID { get; set; }
    }
}
