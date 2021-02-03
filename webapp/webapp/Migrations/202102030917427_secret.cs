namespace webapp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class secret : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Secret", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Secret");
        }
    }
}
