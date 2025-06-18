using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; } = null!;
        public Gender Gender { get; set; }
        public string Nationality { get; set; } = null!;

        public string Address { get; set; } = null!;
        public DateTime DOB { get; set; }
        public string Specialist { get; set; } = null!;
        public Department Department { get; set; } = null!;
        public ICollection<Appointment> Appointments { get; set; } = []!;
        public ICollection<Payroll> Payrolls { get; set; } = []!;



    }
}
