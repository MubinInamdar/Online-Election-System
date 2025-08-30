namespace OnlineElections.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCol : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Results", "PartyName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Results", "PartyName");
        }
    }
}
