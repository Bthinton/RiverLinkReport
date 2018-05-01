namespace RiverLink.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangesToTransactionModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Transaction", "TransponderNumber", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Transaction", "TransponderNumber");
        }
    }
}
