namespace database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cnic : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CrimeCases", "CNIC", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CrimeCases", "CNIC");
        }
    }
}
