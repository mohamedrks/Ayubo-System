namespace AyuboGUI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Added_Vehicle_withAbstract : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Vehicles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VehicleNo = c.String(),
                        Driver = c.Boolean(),
                        StartTime = c.DateTime(),
                        EndTime = c.DateTime(),
                        StartKmReading = c.Decimal(precision: 18, scale: 2),
                        EndKmReading = c.Decimal(precision: 18, scale: 2),
                        WaitingCharge = c.Double(),
                        DriverOverNightCharge = c.Double(),
                        VehicleNightParkRate = c.Double(),
                        VehicleType_Id = c.Int(),
                        Package_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.VehicleTypes", t => t.VehicleType_Id)
                .ForeignKey("dbo.Packages", t => t.Package_Id)
                .Index(t => t.VehicleType_Id)
                .Index(t => t.Package_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vehicles", "Package_Id", "dbo.Packages");
            DropForeignKey("dbo.Vehicles", "VehicleType_Id", "dbo.VehicleTypes");
            DropIndex("dbo.Vehicles", new[] { "Package_Id" });
            DropIndex("dbo.Vehicles", new[] { "VehicleType_Id" });
            DropTable("dbo.Vehicles");
        }
    }
}
