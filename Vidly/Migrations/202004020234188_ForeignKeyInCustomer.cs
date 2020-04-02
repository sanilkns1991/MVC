namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ForeignKeyInCustomer : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "MembershipType_Id", "dbo.MembershipTypes");
            DropIndex("dbo.Customers", new[] { "MembershipType_Id" });
            DropColumn("dbo.Customers", "MembershipId");
            RenameColumn(table: "dbo.Customers", name: "MembershipType_Id", newName: "MembershipId");
            AlterColumn("dbo.Customers", "MembershipId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Customers", "MembershipId");
            AddForeignKey("dbo.Customers", "MembershipId", "dbo.MembershipTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "MembershipId", "dbo.MembershipTypes");
            DropIndex("dbo.Customers", new[] { "MembershipId" });
            AlterColumn("dbo.Customers", "MembershipId", c => c.Byte());
            RenameColumn(table: "dbo.Customers", name: "MembershipId", newName: "MembershipType_Id");
            AddColumn("dbo.Customers", "MembershipId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Customers", "MembershipType_Id");
            AddForeignKey("dbo.Customers", "MembershipType_Id", "dbo.MembershipTypes", "Id");
        }
    }
}
