namespace OnlineElections.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Electiontbl : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Elections",
                c => new
                    {
                        EelectionId = c.Int(nullable: false, identity: true),
                        EelectionName = c.String(nullable: false),
                        PartyName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.EelectionId);
            
            AddColumn("dbo.Voters", "MobileNo", c => c.String(nullable: false, maxLength: 10));
            DropColumn("dbo.Voters", "MobileNno");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Voters", "MobileNno", c => c.String(nullable: false, maxLength: 10));
            DropColumn("dbo.Voters", "MobileNo");
            DropTable("dbo.Elections");
        }
    }
}
