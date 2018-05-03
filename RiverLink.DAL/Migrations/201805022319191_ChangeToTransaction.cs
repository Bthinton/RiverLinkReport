namespace RiverLink.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeToTransaction : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Transaction", "TransactionNumber", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Transaction", "TransactionNumber");
        }
    }
}
