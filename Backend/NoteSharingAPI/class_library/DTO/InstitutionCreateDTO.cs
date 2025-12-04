using System.ComponentModel.DataAnnotations;

namespace class_library.DTO
{
    public class InstitutionCreateDTO
    {
        [Required]
        public string Name { get; set; }
    }
}
