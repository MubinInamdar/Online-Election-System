namespace OnlineElections.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class renameelec : DbMigration
    {
        public override void Up()
        {
            RenameColumn("dbo.Elections", "ElectionId", "EelectionId");
            RenameColumn("dbo.Elections", "ElectionName", "EelectionName");
        }
        
        public override void Down()
        {
        }
    }
}
