namespace Objectivizer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserOrgs : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Organisations", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Organisations", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.Organisations", "ApplicationUser_Id");
            DropColumn("dbo.AspNetUsers", "Surname");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Surname", c => c.String());
            AddColumn("dbo.Organisations", "ApplicationUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Organisations", "ApplicationUser_Id");
            AddForeignKey("dbo.Organisations", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
