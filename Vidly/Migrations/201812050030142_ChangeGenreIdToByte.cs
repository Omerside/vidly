namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeGenreIdToByte : DbMigration
    {
        public override void Up()
        {

        }
        
        public override void Down()
        {

            AlterColumn("dbo.Movies", "GenreId", c => c.Byte());
            AlterColumn("dbo.Movies", "GenreId", c => c.Int(nullable: false));

        }
    }
}
