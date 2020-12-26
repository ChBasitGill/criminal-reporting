namespace database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class checks : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Stations", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Stations", "Location", c => c.String(nullable: false));
            AlterColumn("dbo.Stations", "ContactInfo", c => c.String(nullable: false));
            AlterColumn("dbo.Stations", "MailAddress", c => c.String(nullable: false));
            AlterColumn("dbo.Stations", "StationBoundries", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Stations", "StationBoundries", c => c.String());
            AlterColumn("dbo.Stations", "MailAddress", c => c.String());
            AlterColumn("dbo.Stations", "ContactInfo", c => c.String());
            AlterColumn("dbo.Stations", "Location", c => c.String());
            AlterColumn("dbo.Stations", "Name", c => c.String(maxLength: 50));
        }
    }
}
