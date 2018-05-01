namespace RiverLink.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeToTransactionModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Transaction", "Transponder_Transponder_Id", "dbo.Transponder");
            DropForeignKey("dbo.Transaction", "Vehicle_Vehicle_Id", "dbo.Vehicle");
            DropIndex("dbo.Transaction", new[] { "Transponder_Transponder_Id" });
            DropIndex("dbo.Transaction", new[] { "Vehicle_Vehicle_Id" });
            AlterColumn("dbo.Transaction", "Transponder_Transponder_Id", c => c.Int());
            AlterColumn("dbo.Transaction", "Vehicle_Vehicle_Id", c => c.Int());
            CreateIndex("dbo.Transaction", "Transponder_Transponder_Id");
            CreateIndex("dbo.Transaction", "Vehicle_Vehicle_Id");
            AddForeignKey("dbo.Transaction", "Transponder_Transponder_Id", "dbo.Transponder", "Transponder_Id");
            AddForeignKey("dbo.Transaction", "Vehicle_Vehicle_Id", "dbo.Vehicle", "Vehicle_Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transaction", "Vehicle_Vehicle_Id", "dbo.Vehicle");
            DropForeignKey("dbo.Transaction", "Transponder_Transponder_Id", "dbo.Transponder");
            DropIndex("dbo.Transaction", new[] { "Vehicle_Vehicle_Id" });
            DropIndex("dbo.Transaction", new[] { "Transponder_Transponder_Id" });
            AlterColumn("dbo.Transaction", "Vehicle_Vehicle_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Transaction", "Transponder_Transponder_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Transaction", "Vehicle_Vehicle_Id");
            CreateIndex("dbo.Transaction", "Transponder_Transponder_Id");
            AddForeignKey("dbo.Transaction", "Vehicle_Vehicle_Id", "dbo.Vehicle", "Vehicle_Id", cascadeDelete: true);
            AddForeignKey("dbo.Transaction", "Transponder_Transponder_Id", "dbo.Transponder", "Transponder_Id", cascadeDelete: true);
        }
    }
}
