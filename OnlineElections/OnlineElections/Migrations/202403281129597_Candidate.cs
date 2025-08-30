namespace OnlineElections.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Candidate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Candidates", "NameC", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Candidates", "NameC");
        }
    }
}
