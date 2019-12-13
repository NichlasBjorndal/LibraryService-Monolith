using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryServiceMonolithic.Models
{
    public class Order
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime OrderTime { get; set; }
        public bool IsCompleted { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
    }
}
