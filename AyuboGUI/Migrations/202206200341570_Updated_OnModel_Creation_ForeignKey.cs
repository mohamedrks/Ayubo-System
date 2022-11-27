namespace AyuboGUI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Updated_OnModel_Creation_ForeignKey : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Vehicles", "VehicleType_Id", "dbo.VehicleTypes");
            DropForeignKey("dbo.Vehicles", "Package_Id", "dbo.Packages");
            DropIndex("dbo.Vehicles", new[] { "VehicleType_Id" });
            AlterColumn("dbo.Vehicles", "VehicleType_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Vehicles", "VehicleType_Id");
            AddForeignKey("dbo.Vehicles", "VehicleType_Id", "dbo.VehicleTypes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Vehicles", "Package_Id", "dbo.Packages", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vehicles", "Package_Id", "dbo.Packages");
            DropForeignKey("dbo.Vehicles", "VehicleType_Id", "dbo.VehicleTypes");
            DropIndex("dbo.Vehicles", new[] { "VehicleType_Id" });
            AlterColumn("dbo.Vehicles", "VehicleType_Id", c => c.Int());
            CreateIndex("dbo.Vehicles", "VehicleType_Id");
            AddForeignKey("dbo.Vehicles", "Package_Id", "dbo.Packages", "Id");
            AddForeignKey("dbo.Vehicles", "VehicleType_Id", "dbo.VehicleTypes", "Id");
        }
    }
}
