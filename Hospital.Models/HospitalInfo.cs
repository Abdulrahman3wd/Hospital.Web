using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Models
{
    public class HospitalInfo
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Type { get; set; } = null!;
        public string City { get; set; } = null!;
        public string PinCode { get; set; } = null!;
        public string Country { get; set; } = null!;
        public ICollection<Room> Rooms { get; set; } = new HashSet<Room>();
        
        public ICollection<Contact> Contacts { get; set; } = new HashSet<Contact>();




    }
}
