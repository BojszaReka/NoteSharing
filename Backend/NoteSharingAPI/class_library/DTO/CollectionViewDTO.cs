using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace class_library.DTO
{
    public class CollectionViewDTO
    {
        public Guid ID { get; set; }
        public Guid UserID { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public bool Private { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
