namespace OnlineElections.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Resulttbl : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Results",
                c => new
                    {
                        ResultId = c.Int(nullable: false, identity: true),
                        ElectionId = c.Int(nullable: false),
                        VoterId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ResultId)
                .ForeignKey("dbo.Elections", t => t.ElectionId, cascadeDelete: true)
                .ForeignKey("dbo.Voters", t => t.VoterId, cascadeDelete: true)
                .Index(t => t.ElectionId)
                .Index(t => t.VoterId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Results", "VoterId", "dbo.Voters");
            DropForeignKey("dbo.Results", "ElectionId", "dbo.Elections");
            DropIndex("dbo.Results", new[] { "VoterId" });
            DropIndex("dbo.Results", new[] { "ElectionId" });
            DropTable("dbo.Results");
        }
    }
}
