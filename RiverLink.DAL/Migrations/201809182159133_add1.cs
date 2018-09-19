namespace RiverLink.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.BankTransaction", "TransactionDate", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.BankTransaction", "TransactionDate", c => c.DateTime(nullable: false));
        }
    }
}
