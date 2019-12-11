using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryServiceMonolithic.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrdTime { get; set; }
        public bool IsCompleted { get; set; }
        public int BookId { get; set; } 
        public OrderedBook OrderedBook { get; set; }
    }
}
