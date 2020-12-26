namespace database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class imagepath : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CrimeCases", "CaseImages", c => c.String());
            AlterColumn("dbo.CrimeCases", "Name", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CrimeCases", "Name", c => c.String());
            DropColumn("dbo.CrimeCases", "CaseImages");
        }
    }
}
