namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateCustomerDob : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Customers SET DateOfBirth = 1995-02-15 WHERE id = 1;");
            Sql("UPDATE Customers SET DateOfBirth = 2001-11-10 WHERE id = 2;");
            Sql("UPDATE Customers SET DateOfBirth = 2018-01-15 WHERE id = 3;");
        }
        
        public override void Down()
        {
        }
    }
}
