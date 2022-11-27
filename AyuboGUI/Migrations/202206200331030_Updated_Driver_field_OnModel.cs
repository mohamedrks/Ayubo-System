namespace AyuboGUI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Updated_Driver_field_OnModel : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Vehicles", "Driver");
            RenameColumn(table: "dbo.Vehicles", name: "Driver1", newName: "Driver");
            AddColumn("dbo.Vehicles", "Tarrif", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Vehicles", "Tarrif");
            RenameColumn(table: "dbo.Vehicles", name: "Driver", newName: "Driver1");
            AddColumn("dbo.Vehicles", "Driver", c => c.Boolean());
        }
    }
}
