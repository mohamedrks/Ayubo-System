using System;
using System.Collections.Generic;
using System.Text;

namespace AyuboGUI.Models
{
    public class Vehicle
    {
        public int Id { get; set; }

        public VehicleType VehicleType { get; set; }

        public string VehicleNo { get; set; }

        public float Tarrif { get; set; }
    }
}
