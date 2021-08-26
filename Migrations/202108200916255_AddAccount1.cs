namespace Bank.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAccount1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Acounts", "AccountNumber", c => c.String(nullable: false, maxLength: 12));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Acounts", "AccountNumber", c => c.String(maxLength: 12));
        }
    }
}
