using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryServiceMonolithic.Models
{
    public class PhysicalBook
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Book Book { get; set; }
        public int BookId { get; set; }
    }
}
