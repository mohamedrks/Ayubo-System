using System;
using System.Collections.Generic;
using System.Text;

namespace Ayubo_System
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

        // public DateTime StartTime { get; set; }

        // public DateTime EndTime { get; set; }

        public Package Package { get; set; }

        public double WaitingCharge { get; set; }

        public double DriverOverNightCharge { get; set; }

        public double VehicleNightParkRate { get; set; }

        public override float Tarrif { get ; set ; }

        public double DayTourRentalCalculation(string vehicleNo, Package package,DateTime startTime,DateTime endTime,float startKmReading,float endKmReading )
        {
            double totalHours = (endTime - startTime).TotalHours;
            double baseHirecharge = package.StandardRate;
            double waitCharge = (totalHours - package.MaxHoursLimit) * WaitingCharge;
            double extraKmCharge = (package.MaxKmLimit - (endKmReading - startKmReading)) * package.ExtraKmRate;

            var totalDayTourAmount = baseHirecharge + waitCharge + extraKmCharge;
            return totalDayTourAmount;
        }

        public double LongTourRentalCalculation(string vehicleNo, Package package, DateTime startDate, DateTime endDate, float startKmReading, float endKmReading)
        {
            double TotalNumberOfDays = (endDate - startDate).TotalDays;
            double baseHirecharge = package.StandardRate;
            double driverOverNightStayCharge = (TotalNumberOfDays >= 2) ? (TotalNumberOfDays - 1) * DriverOverNightCharge : 0;
            double extraKmCharge = (package.MaxKmLimit - (endKmReading - startKmReading)) * package.ExtraKmRate;

            var totalLongTourAmount = baseHirecharge + driverOverNightStayCharge + extraKmCharge;
            return totalLongTourAmount;
        }
    }
}
