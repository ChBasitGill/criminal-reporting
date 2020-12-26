namespace database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CrimeCases",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        Gender = c.String(),
                        Age = c.Int(nullable: false),
                        CrimeInfo = c.String(),
                        DateOfCrime = c.DateTime(nullable: false),
                        Contact = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Stations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        Location = c.String(),
                        ContactInfo = c.String(),
                        MailAddress = c.String(),
                        StationBoundries = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Stations");
            DropTable("dbo.CrimeCases");
        }
    }
}
