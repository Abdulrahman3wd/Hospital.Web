using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Models
{
    public class Insurance
    {
        public int Id { get; set; }
        public string PolicyNumber { get; set; } = null!; 
        public string StartDate { get; set; } = null!;
        public string EndDate { get; set; } = null!;
        public ICollection<Bill> Bills { get; set; } = new HashSet<Bill>();


    }
}
