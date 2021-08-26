namespace Bank.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel1111 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "Email", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "Email", c => c.String());
        }
    }
}
