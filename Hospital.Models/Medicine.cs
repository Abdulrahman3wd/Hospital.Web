using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Models
{
    public class Medicine
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!; 
        public string Type { get; set; } = null!;
        public decimal Cost { get; set; }
        public string Description { get; set; } = null!;
        public ICollection<MedicineReport> medicineReport { get; set; } = new HashSet<MedicineReport>();
        public ICollection<PrescribedMedicine> prescribedMedicine { get; set; } = new HashSet<PrescribedMedicine>();
    }
}
