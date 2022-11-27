using System;
using System.Collections.Generic;
using System.Text;

namespace Ayubo_System
{
    public abstract class Vehicle
    {
        public VehicleType VehicleType { get; set; }

        public string VehicleNo { get; set; }

        public abstract float Tarrif { get; set; }

    }


    //public enum VehicleType
    //{
    //    SUV,
    //    SmallCar,
    //    SedanCar,
    //    JeepWD,
    //    SevenSeaterVan,
    //    CommuterVan
    //}

    //public enum Packages
    //{
    //    AirportDrop,
    //    AirportPickup,
    //    HundredKmPerDay,
    //    TwoHundredKmPerDay
    //}
}
