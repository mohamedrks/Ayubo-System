namespace AyuboGUI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Added_Vehicle_withAbstract_rental : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vehicles", "Driver1", c => c.Boolean());
            AddColumn("dbo.Vehicles", "RentedDate", c => c.DateTime());
            AddColumn("dbo.Vehicles", "ReturnedDate", c => c.DateTime());
            AddColumn("dbo.Vehicles", "DailyRental", c => c.Single());
            AddColumn("dbo.Vehicles", "WeeklyRental", c => c.Single());
            AddColumn("dbo.Vehicles", "MonthlyRental", c => c.Single());
            AddColumn("dbo.Vehicles", "DailyDriverCost", c => c.Single());
            AddColumn("dbo.Vehicles", "Discriminator", c => c.String(nullable: false, maxLength: 128));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Vehicles", "Discriminator");
            DropColumn("dbo.Vehicles", "DailyDriverCost");
            DropColumn("dbo.Vehicles", "MonthlyRental");
            DropColumn("dbo.Vehicles", "WeeklyRental");
            DropColumn("dbo.Vehicles", "DailyRental");
            DropColumn("dbo.Vehicles", "ReturnedDate");
            DropColumn("dbo.Vehicles", "RentedDate");
            DropColumn("dbo.Vehicles", "Driver1");
        }
    }
}
