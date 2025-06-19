using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Models
{
    public class Supplier
    {
        public int Id { get; set; }
        public string Company { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Email { get; set; }=null!;
        public string Address { get; set; } = null!;
        public ICollection<Supplier> Suppliers { get; set; } = new HashSet<Supplier>();
    }
}
