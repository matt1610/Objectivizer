namespace Objectivizer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addeddbsets : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        GroupId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        LevelId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GroupId)
                .ForeignKey("dbo.Levels", t => t.LevelId, cascadeDelete: true)
                .Index(t => t.LevelId);
            
            CreateTable(
                "dbo.Objectives",
                c => new
                    {
                        ObjectiveId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Weight = c.Int(nullable: false),
                        Group_GroupId = c.Int(),
                        Team_TeamId = c.Int(),
                        Level_LevelId = c.Int(),
                    })
                .PrimaryKey(t => t.ObjectiveId)
                .ForeignKey("dbo.Groups", t => t.Group_GroupId)
                .ForeignKey("dbo.Teams", t => t.Team_TeamId)
                .ForeignKey("dbo.Levels", t => t.Level_LevelId)
                .Index(t => t.Group_GroupId)
                .Index(t => t.Team_TeamId)
                .Index(t => t.Level_LevelId);
            
            CreateTable(
                "dbo.Teams",
                c => new
                    {
                        TeamId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        GroupId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TeamId)
                .ForeignKey("dbo.Groups", t => t.GroupId, cascadeDelete: true)
                .Index(t => t.GroupId);
            
            CreateTable(
                "dbo.Levels",
                c => new
                    {
                        LevelId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.LevelId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Objectives", "Level_LevelId", "dbo.Levels");
            DropForeignKey("dbo.Groups", "LevelId", "dbo.Levels");
            DropForeignKey("dbo.Teams", "GroupId", "dbo.Groups");
            DropForeignKey("dbo.Objectives", "Team_TeamId", "dbo.Teams");
            DropForeignKey("dbo.Objectives", "Group_GroupId", "dbo.Groups");
            DropIndex("dbo.Teams", new[] { "GroupId" });
            DropIndex("dbo.Objectives", new[] { "Level_LevelId" });
            DropIndex("dbo.Objectives", new[] { "Team_TeamId" });
            DropIndex("dbo.Objectives", new[] { "Group_GroupId" });
            DropIndex("dbo.Groups", new[] { "LevelId" });
            DropTable("dbo.Levels");
            DropTable("dbo.Teams");
            DropTable("dbo.Objectives");
            DropTable("dbo.Groups");
        }
    }
}
