using System;
using System.Collections.Generic;
using System.Text;

namespace Ayubo_System
{
    public class Package
    {
        public string PackageName { get; set; }
        public bool IsApplicable { get; set; }
        public double StandardRate { get; set; }
        public double ExtraKmRate { get; set; }
        public double MaxKmLimit { get; set; }
        public double MaxHoursLimit { get; set; }
    }
}
