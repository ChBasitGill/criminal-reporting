namespace database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CrimeCases",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        CNIC = c.String(nullable: false),
                        Address = c.String(),
                        Gender = c.String(),
                        Age = c.Int(nullable: false),
                        CrimeInfo = c.String(),
                        DateOfCrime = c.DateTime(nullable: false),
                        Contact = c.String(),
                        CaseImages = c.String(),
                        StationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Stations", t => t.StationId, cascadeDelete: true)
                .Index(t => t.StationId);
            
            CreateTable(
                "dbo.Stations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Location = c.String(nullable: false),
                        ContactInfo = c.String(nullable: false),
                        MailAddress = c.String(nullable: false),
                        StationBoundries = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CrimeCases", "StationId", "dbo.Stations");
            DropIndex("dbo.CrimeCases", new[] { "StationId" });
            DropTable("dbo.Stations");
            DropTable("dbo.CrimeCases");
        }
    }
}
