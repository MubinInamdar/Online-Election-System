namespace OnlineElections.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCol1 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Results", name: "ElectionId", newName: "EelectionId");
            RenameIndex(table: "dbo.Results", name: "IX_ElectionId", newName: "IX_EelectionId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Results", name: "IX_EelectionId", newName: "IX_ElectionId");
            RenameColumn(table: "dbo.Results", name: "EelectionId", newName: "ElectionId");
        }
    }
}
