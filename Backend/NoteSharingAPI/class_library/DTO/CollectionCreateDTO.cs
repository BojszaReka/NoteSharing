using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace class_library.DTO
{
    public class CollectionCreateDTO
    {
        public Guid UserID { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public bool Private { get; set; }
    }
}

