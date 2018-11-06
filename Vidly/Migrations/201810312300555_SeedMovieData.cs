namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedMovieData : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Movies (Name, ReleaseDate, AddedDate, Stock, Genre_Id) VALUES('Shrek', '1995-02-15', '2015-03-14', 4, 1); ");
            Sql("INSERT INTO Movies (Name, ReleaseDate, AddedDate, Stock, Genre_Id) VALUES('Shrek 2', '2000-01-02', '2015-03-14', 3, 0); ");
            Sql("INSERT INTO Movies (Name, ReleaseDate, AddedDate, Stock, Genre_Id) VALUES('Shrek: Swamp War', '2003-11-10', '2015-03-14', 1, 3); ");
            Sql("INSERT INTO Movies (Name, ReleaseDate, AddedDate, Stock, Genre_Id) VALUES('Shrek: Infinity Ogre', '2006-12-12', '2015-03-14', 2, 4); ");
            Sql("INSERT INTO Movies (Name, ReleaseDate, AddedDate, Stock, Genre_Id) VALUES('Shrek Christmas Special', '2012-12-25', '2015-03-14', 4, 2); ");
        }
        
        public override void Down()
        {
        }
    }
}
