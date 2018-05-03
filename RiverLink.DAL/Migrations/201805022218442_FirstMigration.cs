namespace RiverLink.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Transaction",
                c => new
                    {
                        Transaction_Id = c.Int(nullable: false, identity: true),
                        TransactionDate = c.DateTime(nullable: false),
                        PostedDate = c.DateTime(nullable: false),
                        TransactionStatus = c.String(),
                        Plaza = c.String(),
                        Journal_Id = c.Int(nullable: false),
                        TransponderNumber = c.Int(nullable: false),
                        TransactionType = c.String(),
                        Amount = c.Double(nullable: false),
                        TransactionDescription = c.String(maxLength: 50),
                        Lane = c.Int(nullable: false),
                        PlateNumber = c.String(maxLength: 20),
                        VehicleClass_Id = c.Short(nullable: false),
                        Transponder_Transponder_Id = c.Int(),
                        Vehicle_Vehicle_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Transaction_Id)
                .ForeignKey("dbo.Transponder", t => t.Transponder_Transponder_Id)
                .ForeignKey("dbo.Vehicle", t => t.Vehicle_Vehicle_Id)
                .Index(t => t.Transponder_Transponder_Id)
                .Index(t => t.Vehicle_Vehicle_Id);
            
            CreateTable(
                "dbo.Transponder",
                c => new
                    {
                        Transponder_Id = c.Int(nullable: false, identity: true),
                        TransponderNumber = c.String(),
                        TransponderType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Transponder_Id);
            
            CreateTable(
                "dbo.Vehicle",
                c => new
                    {
                        Vehicle_Id = c.Int(nullable: false, identity: true),
                        PlateNumber = c.String(maxLength: 20),
                        Make = c.String(maxLength: 32),
                        Model = c.String(maxLength: 32),
                        Year = c.Int(nullable: false),
                        VehicleState = c.String(maxLength: 2),
                        VehicleStatus = c.String(),
                        Classification = c.Int(nullable: false),
                        VehicleClass_VehicleClass_Id = c.Short(),
                    })
                .PrimaryKey(t => t.Vehicle_Id)
                .ForeignKey("dbo.VehicleClass", t => t.VehicleClass_VehicleClass_Id)
                .Index(t => t.VehicleClass_VehicleClass_Id);
            
            CreateTable(
                "dbo.VehicleClass",
                c => new
                    {
                        VehicleClass_Id = c.Short(nullable: false, identity: true),
                        VehicleDescription = c.String(maxLength: 32),
                        Price = c.Double(nullable: false),
                        PriceType = c.Int(nullable: false),
                        Classification = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.VehicleClass_Id);
            
            CreateTable(
                "dbo.VehicleTransponder",
                c => new
                    {
                        Vehicle_Vehicle_Id = c.Int(nullable: false),
                        Transponder_Transponder_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Vehicle_Vehicle_Id, t.Transponder_Transponder_Id })
                .ForeignKey("dbo.Vehicle", t => t.Vehicle_Vehicle_Id, cascadeDelete: true)
                .ForeignKey("dbo.Transponder", t => t.Transponder_Transponder_Id, cascadeDelete: true)
                .Index(t => t.Vehicle_Vehicle_Id)
                .Index(t => t.Transponder_Transponder_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vehicle", "VehicleClass_VehicleClass_Id", "dbo.VehicleClass");
            DropForeignKey("dbo.VehicleTransponder", "Transponder_Transponder_Id", "dbo.Transponder");
            DropForeignKey("dbo.VehicleTransponder", "Vehicle_Vehicle_Id", "dbo.Vehicle");
            DropForeignKey("dbo.Transaction", "Vehicle_Vehicle_Id", "dbo.Vehicle");
            DropForeignKey("dbo.Transaction", "Transponder_Transponder_Id", "dbo.Transponder");
            DropIndex("dbo.VehicleTransponder", new[] { "Transponder_Transponder_Id" });
            DropIndex("dbo.VehicleTransponder", new[] { "Vehicle_Vehicle_Id" });
            DropIndex("dbo.Vehicle", new[] { "VehicleClass_VehicleClass_Id" });
            DropIndex("dbo.Transaction", new[] { "Vehicle_Vehicle_Id" });
            DropIndex("dbo.Transaction", new[] { "Transponder_Transponder_Id" });
            DropTable("dbo.VehicleTransponder");
            DropTable("dbo.VehicleClass");
            DropTable("dbo.Vehicle");
            DropTable("dbo.Transponder");
            DropTable("dbo.Transaction");
        }
    }
}
