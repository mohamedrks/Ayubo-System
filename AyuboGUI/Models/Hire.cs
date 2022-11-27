using System;
using System.Collections.Generic;
using System.Text;

namespace AyuboGUI.Models
{
    public class Hire : Vehicle
    {

        public bool Driver
        {
            get
            {
                return Driver;
            }

            set
            {
                Driver = true;
            }
        }

        public decimal StartKmReading { get; set; }

        public decimal EndKmReading { get; set; }

        public Package Package { get; set; }

        public double WaitingCharge { get; set; }

        public double DriverOverNightCharge { get; set; }

        public double VehicleNightParkRate { get; set; }


    }
}
