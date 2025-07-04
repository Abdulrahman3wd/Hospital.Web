﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Models
{
    public class Lab
    {
        public int Id { get; set; }
        public string labNumber { get; set; } = null!; 
        public ApplicationUser Patient { get; set; } = null!;
        public string TestType { get; set; } = null!;
        public string TestCode { get; set; } = null!;
        public int Weight { get; set; }
        public int Height { get; set; }
        public int  BloodPressure { get; set; } 
        public int Temperature { get; set; }
        public string TestResult { get; set; } = null!;


        
    }
}
