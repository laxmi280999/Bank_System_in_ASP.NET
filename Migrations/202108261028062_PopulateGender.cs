namespace Bank.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGender : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genders(GenderType) Values ('Male')");
            Sql("INSERT INTO Genders(GenderType) Values ('Female')");
            Sql("INSERT INTO Genders(GenderType) Values ('Prefer Not To Say')");
        }
        
        public override void Down()
        {
        }
    }
}
