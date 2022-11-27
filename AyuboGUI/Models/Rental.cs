using System;
using System.Collections.Generic;
using System.Text;

namespace AyuboGUI.Models
{
    public class Rental : Vehicle
    {
        //public bool Driver { get; set; }

        //public DateTime RentedDate { get; set; }

        //public DateTime ReturnedDate { get; set; }

        public float DailyRental { get; set; }

        public float WeeklyRental { get; set; }

        public float MonthlyRental { get; set; }

        public float DailyDriverCost { get; set; }
    }
}
