namespace OnlineElections.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Seedadmin : DbMigration
    {
        public override void Up()
        {
            Sql("Insert Into Admins (AdminName,AdminEmail,AdminPassword) values('Admin','admin@gmail.com','Admin@123') ");
        }
        
        public override void Down()
        {
        }
    }
}
