using System;
using System.Collections.Generic;
using System.Text;

namespace Ayubo_System
{
    public class Rental : Vehicle
    {

        public bool Driver { get; set; }

        public DateTime RentedDate { get; set; }

        public DateTime ReturnedDate { get; set; }

        public float DailyRental { get; set; }

        public float WeeklyRental { get; set; }

        public float MonthlyRental { get; set; }

        public float DailyDriverCost { get; set; }
        public override float Tarrif { get ; set; }

        public double RentCalculation(string VehicleNo, DateTime RentedDate, DateTime ReturnedDate, bool Driver)
        {
            double TotalNumberOfDays = (ReturnedDate - RentedDate).TotalDays;

            double months = TotalNumberOfDays / 30;
            double weeks = (TotalNumberOfDays % 30) / 7;
            double days = (TotalNumberOfDays % 30) % 7;

            double TotalRent = months * MonthlyRental + weeks * WeeklyRental + days * DailyRental;

            if (Driver)
            {
                _ = DailyDriverCost * TotalNumberOfDays;
            }

            return TotalRent;
        }
    }
}
