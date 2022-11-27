namespace AyuboGUI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Added_Packages : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Packages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PackageName = c.String(),
                        IsApplicable = c.Boolean(nullable: false),
                        StandardRate = c.Double(nullable: false),
                        ExtraKmRate = c.Double(nullable: false),
                        MaxKmLimit = c.Double(nullable: false),
                        MaxHoursLimit = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Packages");
        }
    }
}
