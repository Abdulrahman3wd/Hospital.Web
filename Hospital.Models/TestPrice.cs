using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Models
{
    public class TestPrice
    {
        public int Id { get; set; }
        public string TestCode { get; set; } = null!;
        public decimal Price {  get; set; }

        public Lab Lab { get; set; } = null!;
        public Bill Bill { get; set; } = null!;

        
    }
}
