namespace Bank.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateAccountType : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO AccountTypes(Type) VALUES ('Current')");
            Sql("INSERT INTO AccountTypes(Type) VALUES ('Savings')");
        }
        
        public override void Down()
        {
        }
    }
}
