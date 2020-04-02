namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MembershipIdAddedBack : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "MembershipId", c => c.Byte(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "MembershipId");
        }
    }
}
