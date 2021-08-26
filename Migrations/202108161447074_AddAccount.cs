namespace Bank.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAccount : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Acounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        AccountTypeId = c.Int(nullable: false),
                        AccountNumber = c.String(maxLength: 12),
                        Balance = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AccountTypes", t => t.AccountTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.AccountTypeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Acounts", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Acounts", "AccountTypeId", "dbo.AccountTypes");
            DropIndex("dbo.Acounts", new[] { "AccountTypeId" });
            DropIndex("dbo.Acounts", new[] { "CustomerId" });
            DropTable("dbo.Acounts");
        }
    }
}
