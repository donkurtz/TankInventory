using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileApplication.Models
{
    public class CTankData
    {
        public string TankNumber { get; set; }
        public string Product { get; set; }
        public double Level { get; set; }
        public bool Unavailable { get; set; }
        public double MaxBlendPercentage { get; set; }
        public string Comment { get; set; }
    }
}
