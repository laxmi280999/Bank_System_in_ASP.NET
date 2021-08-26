namespace Bank.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel111 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "Gender", c => c.String(nullable: false));
            AlterColumn("dbo.Customers", "Address", c => c.String(nullable: false));
            AlterColumn("dbo.Customers", "Phone", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "Phone", c => c.String());
            AlterColumn("dbo.Customers", "Address", c => c.String());
            AlterColumn("dbo.Customers", "Gender", c => c.String());
        }
    }
}
