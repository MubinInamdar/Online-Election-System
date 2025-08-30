namespace OnlineElections.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Try : DbMigration
    {
        public override void Up()
        {
            RenameColumn("dbo.Elections", "EelectionId", "ElectionId");
            RenameColumn("dbo.Elections", "EelectionName", "ElectionName");
        }
        
        public override void Down()
        {
        }
    }
}
