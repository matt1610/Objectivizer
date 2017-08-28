namespace Objectivizer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MoreStuff : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Objectives", "OrganisationId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Objectives", "OrganisationId");
        }
    }
}
