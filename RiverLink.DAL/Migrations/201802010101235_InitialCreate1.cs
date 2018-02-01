namespace RiverLink.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate1 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Transaction");
            AlterColumn("dbo.Transaction", "Transaction_Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Transaction", "Journal_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Vehicle", "Year", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Transaction", "Transaction_Id");
            DropColumn("dbo.VehicleClass", "ClassificationDescription");
        }
        
        public override void Down()
        {
            AddColumn("dbo.VehicleClass", "ClassificationDescription", c => c.String(nullable: false, maxLength: 32));
            DropPrimaryKey("dbo.Transaction");
            AlterColumn("dbo.Vehicle", "Year", c => c.Short(nullable: false));
            AlterColumn("dbo.Transaction", "Journal_Id", c => c.Long(nullable: false));
            AlterColumn("dbo.Transaction", "Transaction_Id", c => c.Long(nullable: false, identity: true));
            AddPrimaryKey("dbo.Transaction", "Transaction_Id");
        }
    }
}
