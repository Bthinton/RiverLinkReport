namespace RiverLink.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangesToTransaction2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Transaction", "TransactionStatus", c => c.String());
            AlterColumn("dbo.Transaction", "Plaza", c => c.String(nullable: false));
            AlterColumn("dbo.Transaction", "TransactionType", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Transaction", "TransactionType", c => c.Int(nullable: false));
            AlterColumn("dbo.Transaction", "Plaza", c => c.Int(nullable: false));
            AlterColumn("dbo.Transaction", "TransactionStatus", c => c.Int(nullable: false));
        }
    }
}
