namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChnageColumnName : DbMigration
    {
        public override void Up()
        {
            Sql("ALTER TABLE Movie RENAME COLUMN DateAdded to DateA");  
        }
        
        public override void Down()
        {
        }
    }
}
