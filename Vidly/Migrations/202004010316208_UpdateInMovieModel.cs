namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateInMovieModel : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Movies", "Genre_Name");
            DropColumn("dbo.Movies", "GenreId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "GenreId", c => c.Int(nullable: false));
            AddColumn("dbo.Movies", "Genre_Name", c => c.String());
        }
    }
}
