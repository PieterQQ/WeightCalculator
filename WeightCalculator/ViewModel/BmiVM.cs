using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeightCalculator.ViewModel
{
    public class BmiVM
    {
        public int Height { get; set; }
        public int InitWeight { get; set; }
        public int DesiredWeight { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}