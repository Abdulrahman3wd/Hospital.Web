using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Models
{
    public class Hospital
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string type { get; set; } = null!;
        public string City { get; set; } = null!;
        public string PinCode { get; set; } = null!;
        public string Country { get; set; } = null!;
        public ICollection<Room> Rooms { get; set; } = []!;
        
        public ICollection<Contact> Contacts { get; set; } = []!;




    }
}
