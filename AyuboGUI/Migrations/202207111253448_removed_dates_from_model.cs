namespace AyuboGUI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removed_dates_from_model : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Vehicles", "StartTime");
            DropColumn("dbo.Vehicles", "EndTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Vehicles", "EndTime", c => c.DateTime());
            AddColumn("dbo.Vehicles", "StartTime", c => c.DateTime());
        }
    }
}
