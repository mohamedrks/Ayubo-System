using AyuboGUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AyuboGUI
{
    public class DataAccessService
    {
        private AyuboContext ayuboDbContext;

        public DataAccessService()
        {
            ayuboDbContext = new AyuboContext();
        }

        public List<VehicleType> GetVehicleTypes()
        {
            var vehicleTypes = ayuboDbContext.VehicleType.ToList();
            return vehicleTypes;
        }

        public VehicleType FindVehicleTypes(string vehicleType)
        {
            var foundVehicleType = ayuboDbContext.VehicleType.SingleOrDefault( v => v.TypeName.Equals(vehicleType));
            return foundVehicleType;
        }

        public VehicleType AddVehicleType(VehicleType vehicleType)
        {
            var newVehicleType = ayuboDbContext.VehicleType.Add(vehicleType);
            ayuboDbContext.SaveChanges();
            return newVehicleType;
        }

        public void UpdateVehicleType(VehicleType vehicleType)
        {
            var oldVehicleType = ayuboDbContext.VehicleType.SingleOrDefault(v => v.Id == vehicleType.Id);
            if (oldVehicleType != null)
            {
                oldVehicleType.TypeName = vehicleType.TypeName;
                ayuboDbContext.SaveChanges();
            }
        }

        public bool DeleteVehicleType(VehicleType vehicleType)
        {
            var oldVehicleType = ayuboDbContext.VehicleType.FirstOrDefault(v => v.Id == vehicleType.Id);
            if (oldVehicleType != null)
            {
                ayuboDbContext.VehicleType.Remove(oldVehicleType);
                ayuboDbContext.SaveChanges();
                return true;
            }
            return false;
        }

        // Package.

        public List<Package> Getpackages()
        {
            var packages = ayuboDbContext.Package.ToList();
            return packages;
        }

        public Package FindPackage(string packageName)
        {
            var foundPackage = ayuboDbContext.Package.FirstOrDefault(v => v.PackageName.Equals(packageName));
            return foundPackage;
        }

        public Package Addpackage(Package package)
        {
            var newpackage = ayuboDbContext.Package.Add(package);
            ayuboDbContext.SaveChanges();
            return newpackage;
        }

        public void UpdatePackage(Package package)
        {
            var oldPackage = ayuboDbContext.Package.SingleOrDefault(v => v.Id == package.Id);
            if (oldPackage != null)
            {
                oldPackage.PackageName = package.PackageName;
                oldPackage.IsApplicable = package.IsApplicable;
                oldPackage.StandardRate = package.StandardRate;
                oldPackage.ExtraKmRate = package.ExtraKmRate;
                oldPackage.MaxKmLimit = package.MaxKmLimit;
                oldPackage.MaxHoursLimit = package.MaxHoursLimit;
                ayuboDbContext.SaveChanges();
            }
        }

        public bool DeletePackage(Package package)
        {
            var oldPackage = ayuboDbContext.Package.SingleOrDefault(v => v.Id == package.Id);
            if (oldPackage != null)
            {
                ayuboDbContext.Package.Remove(oldPackage);
                ayuboDbContext.SaveChanges();
                return true;
            }
            return false;
        }

        // Vehicle.

        public List<Hire> GetHireVehicles()
        {
            var hireVehicles = ayuboDbContext.Hire.ToList();
            return hireVehicles;
        }

        public Hire FindHireVehicle(string vehicleNo)
        {
            var foundHireVehicle = ayuboDbContext.Hire.FirstOrDefault(v => v.VehicleNo.Equals(vehicleNo));
            return foundHireVehicle;
        }

        public Hire AddVehicle(Hire hireVehicle)
        {
            var newHireVehicle = ayuboDbContext.Hire.Add(hireVehicle);
            ayuboDbContext.SaveChanges();
            return newHireVehicle;
        }

        public void UpdateHireVehicle(Hire vehicle)
        {
            var oldHireVehicle = ayuboDbContext.Hire.SingleOrDefault(v => v.Id == vehicle.Id);
            if (oldHireVehicle != null)
            {
                oldHireVehicle.VehicleNo = vehicle.VehicleNo;
                oldHireVehicle.VehicleType = vehicle.VehicleType;
                oldHireVehicle.Tarrif = vehicle.Tarrif;

                oldHireVehicle.Driver = vehicle.Driver;
                oldHireVehicle.DriverOverNightCharge = vehicle.DriverOverNightCharge;

                oldHireVehicle.Package = vehicle.Package;
                oldHireVehicle.WaitingCharge = vehicle.WaitingCharge;
                oldHireVehicle.VehicleNightParkRate = vehicle.VehicleNightParkRate;

                ayuboDbContext.SaveChanges();
            }
        }

        public bool DeleteVehicle(Hire vehicle)
        {
            var oldHireVehicle = ayuboDbContext.Hire.SingleOrDefault(v => v.Id == vehicle.Id);
            if (oldHireVehicle != null)
            {
                ayuboDbContext.Hire.Remove(oldHireVehicle);
                ayuboDbContext.SaveChanges();
                return true;
            }
            return false;
        }

        // Rental

        public List<Rental> GetRentalVehicles()
        {
            var rentalVehicles = ayuboDbContext.Rental.ToList();
            return rentalVehicles;
        }

        public Rental FindRentalVehicle(string vehicleNo)
        {
            var foundRentalVehcile = ayuboDbContext.Rental.FirstOrDefault(v => v.VehicleNo.Equals(vehicleNo));
            return foundRentalVehcile;
        }

        public Rental AddRentalVehicle(Rental rentalVehicle)
        {
            var newRentalVehicle = ayuboDbContext.Rental.Add(rentalVehicle);
            ayuboDbContext.SaveChanges();
            return newRentalVehicle;
        }

        public void UpdateRentalVehicle(Rental vehicle)
        {
            var oldRentalVehicle = ayuboDbContext.Rental.SingleOrDefault(v => v.Id == vehicle.Id);
            if (oldRentalVehicle != null)
            {
                oldRentalVehicle.VehicleNo = vehicle.VehicleNo;
                oldRentalVehicle.VehicleType = vehicle.VehicleType;
                oldRentalVehicle.Tarrif = vehicle.Tarrif;
                
                //oldRentalVehicle.Driver = vehicle.Driver;
                oldRentalVehicle.DailyRental = vehicle.DailyRental;

                oldRentalVehicle.DailyRental = vehicle.DailyRental;
                oldRentalVehicle.WeeklyRental = vehicle.WeeklyRental;
                oldRentalVehicle.MonthlyRental = vehicle.MonthlyRental;

                ayuboDbContext.SaveChanges();
            }
        }

        public bool DeleteRentalVehicle(Rental vehicle)
        {
            var oldRentalVehicle = ayuboDbContext.Rental.SingleOrDefault(v => v.Id == vehicle.Id);
            if (oldRentalVehicle != null)
            {
                ayuboDbContext.Rental.Remove(oldRentalVehicle);
                ayuboDbContext.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
