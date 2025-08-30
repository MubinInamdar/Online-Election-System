namespace OnlineElections.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Candidate1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Candidates", "NameC");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Candidates", "NameC", c => c.String());
        }
    }
}
