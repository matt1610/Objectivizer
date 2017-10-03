namespace Objectivizer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserOrganisations : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Organisations", "ApplicationUser_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.AspNetUsers", "Surname", c => c.String());
            CreateIndex("dbo.Organisations", "ApplicationUser_Id");
            AddForeignKey("dbo.Organisations", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Organisations", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Organisations", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.AspNetUsers", "Surname");
            DropColumn("dbo.Organisations", "ApplicationUser_Id");
        }
    }
}
