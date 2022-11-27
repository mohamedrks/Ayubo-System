using AyuboGUI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace AyuboGUI
{
    public class AyuboContext : DbContext
    {
        public AyuboContext()
        : base("Data Source=LAPTOP-5NPAHQ82\\SQLEXPRESS;Initial Catalog=AyuboDatabase;Integrated Security=True")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Rental>()
            //    .Property(b => b.Driver)
            //    .HasColumnName("Driver");

            modelBuilder.Entity<Hire>()
                .HasRequired( p => p.Package);

            modelBuilder.Entity<Vehicle>()
                .HasRequired(v => v.VehicleType);

            //modelBuilder.Entity<Hire>()
            //    .Property(b => b.Driver)
            //    .HasColumnName("Driver");
        }

        public DbSet<VehicleType> VehicleType { get; set; }
        public DbSet<Package> Package { get; set; }
        public DbSet<Vehicle> Vehicle { get; set; }
        public DbSet<Hire> Hire { get; set; }
        public DbSet<Rental> Rental { get; set; }
    }
    
}
