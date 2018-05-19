namespace RiverLink.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangesToTransactionData : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Transaction", "TransponderNumber", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Transaction", "TransponderNumber", c => c.String());
        }
    }
}
