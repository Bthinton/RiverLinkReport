namespace RiverLink.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BankTransaction",
                c => new
                    {
                        Transaction_Id = c.Int(nullable: false, identity: true),
                        TransactionDate = c.DateTime(nullable: false),
                        Amount = c.Double(nullable: false),
                        Comment = c.String(),
                    })
                .PrimaryKey(t => t.Transaction_Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.BankTransaction");
        }
    }
}
