namespace AyuboGUI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removed_driver_from_models : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Vehicles", "RentedDate");
            DropColumn("dbo.Vehicles", "ReturnedDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Vehicles", "ReturnedDate", c => c.DateTime());
            AddColumn("dbo.Vehicles", "RentedDate", c => c.DateTime());
        }
    }
}
