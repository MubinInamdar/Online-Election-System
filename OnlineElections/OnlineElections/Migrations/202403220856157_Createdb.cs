namespace OnlineElections.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Createdb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        AdminId = c.Int(nullable: false, identity: true),
                        AdminName = c.String(nullable: false, maxLength: 100),
                        AdminEmail = c.String(nullable: false),
                        AdminPassword = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.AdminId);
            
            CreateTable(
                "dbo.Candidates",
                c => new
                    {
                        CandidateID = c.Int(nullable: false, identity: true),
                        VoterId = c.Int(nullable: false),
                        PartyName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CandidateID)
                .ForeignKey("dbo.Voters", t => t.VoterId, cascadeDelete: true)
                .Index(t => t.VoterId);
            
            CreateTable(
                "dbo.Voters",
                c => new
                    {
                        VoterId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        FatherName = c.String(nullable: false),
                        Age = c.Int(nullable: false),
                        Gender = c.String(nullable: false),
                        AadhaarNo = c.String(nullable: false, maxLength: 12),
                        PanNo = c.String(nullable: false, maxLength: 10),
                        City = c.String(nullable: false),
                        Religion = c.String(nullable: false),
                        EmailId = c.String(nullable: false),
                        MobileNno = c.String(nullable: false, maxLength: 10),
                        Password = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.VoterId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Candidates", "VoterId", "dbo.Voters");
            DropIndex("dbo.Candidates", new[] { "VoterId" });
            DropTable("dbo.Voters");
            DropTable("dbo.Candidates");
            DropTable("dbo.Admins");
        }
    }
}
