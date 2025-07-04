﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
        public bool IsDoctor { get; set; }
        public string Specialist { get; set; } = null!;
        public Department Department { get; set; } = null!;
        [NotMapped]
        public ICollection<Appointment> Appointments { get; set; } = new HashSet<Appointment>();
        public ICollection<Payroll> Payrolls { get; set; } =new HashSet<Payroll>();

        public ICollection<PatientReport> patientReports { get; set; }


    }
}
