namespace RiverLink.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangesToTransaction3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Transaction", "TransactionDescription", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Transaction", "TransactionDescription", c => c.String(maxLength: 20));
        }
    }
}
