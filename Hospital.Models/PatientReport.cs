using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Models
{
    public class PatientReport
    {
        public int Id { get; set; }
        public string Diagnose { get; set; } = null!;
        public ApplicationUser Doctor { get; set; } = null!;
        public ApplicationUser Patient { get; set; } = null!;
        public ICollection<PrescribedMedicine> prescribedMedicine { get; set; } = new HashSet<PrescribedMedicine>();


    }
}
