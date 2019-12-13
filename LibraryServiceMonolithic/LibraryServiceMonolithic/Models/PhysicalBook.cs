using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryServiceMonolithic.Models
{
    public class PhysicalBook
    {
        public int Id { get; set; }
        public Book Book { get; set; }
        public int BookId { get; set; }
    }
}
