namespace RiverLink.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Transaction",
                c => new
                    {
                        Transaction_Id = c.Long(nullable: false, identity: true),
                        TransactionDate = c.DateTime(nullable: false),
                        PostedDate = c.DateTime(nullable: false),
                        TransactionStatus = c.Int(nullable: false),
                        Plaza = c.Int(nullable: false),
                        Journal_Id = c.Long(nullable: false),
                        TransactionType = c.Int(nullable: false),
                        Amount = c.Double(nullable: false),
                        TransactionDescription = c.String(maxLength: 20),
                        Lane = c.Int(nullable: false),
                        PlateNumber = c.String(nullable: false, maxLength: 20),
                        Transponder_Transponder_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Transaction_Id)
                .ForeignKey("dbo.Transponder", t => t.Transponder_Transponder_Id, cascadeDelete: true)
                .ForeignKey("dbo.Vehicle", t => t.PlateNumber, cascadeDelete: true)
                .Index(t => t.PlateNumber)
                .Index(t => t.Transponder_Transponder_Id);
            
            CreateTable(
                "dbo.Transponder",
                c => new
                    {
                        Transponder_Id = c.Int(nullable: false, identity: true),
                        TransponderType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Transponder_Id);
            
            CreateTable(
                "dbo.Vehicle",
                c => new
                    {
                        PlateNumber = c.String(nullable: false, maxLength: 20),
                        Make = c.String(maxLength: 32),
                        Model = c.String(maxLength: 32),
                        Year = c.Short(nullable: false),
                        VehicleState = c.String(nullable: false, maxLength: 2),
                        VehicleStatus = c.String(),
                    })
                .PrimaryKey(t => t.PlateNumber);
            
            CreateTable(
                "dbo.VehicleClass",
                c => new
                    {
                        VehicleClass_Id = c.Short(nullable: false, identity: true),
                        VehicleDescription = c.String(maxLength: 32),
                        ClassificationDescription = c.String(nullable: false, maxLength: 32),
                        Price = c.Double(nullable: false),
                        PriceType = c.Int(nullable: false),
                        Classification = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.VehicleClass_Id);
            
            CreateTable(
                "dbo.VehicleTransponder",
                c => new
                    {
                        Vehicle_PlateNumber = c.String(nullable: false, maxLength: 20),
                        Transponder_Transponder_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Vehicle_PlateNumber, t.Transponder_Transponder_Id })
                .ForeignKey("dbo.Vehicle", t => t.Vehicle_PlateNumber, cascadeDelete: true)
                .ForeignKey("dbo.Transponder", t => t.Transponder_Transponder_Id, cascadeDelete: true)
                .Index(t => t.Vehicle_PlateNumber)
                .Index(t => t.Transponder_Transponder_Id);
            
            CreateTable(
                "dbo.VehicleClassVehicle",
                c => new
                    {
                        VehicleClass_VehicleClass_Id = c.Short(nullable: false),
                        Vehicle_PlateNumber = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => new { t.VehicleClass_VehicleClass_Id, t.Vehicle_PlateNumber })
                .ForeignKey("dbo.VehicleClass", t => t.VehicleClass_VehicleClass_Id, cascadeDelete: true)
                .ForeignKey("dbo.Vehicle", t => t.Vehicle_PlateNumber, cascadeDelete: true)
                .Index(t => t.VehicleClass_VehicleClass_Id)
                .Index(t => t.Vehicle_PlateNumber);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transaction", "PlateNumber", "dbo.Vehicle");
            DropForeignKey("dbo.Transaction", "Transponder_Transponder_Id", "dbo.Transponder");
            DropForeignKey("dbo.VehicleClassVehicle", "Vehicle_PlateNumber", "dbo.Vehicle");
            DropForeignKey("dbo.VehicleClassVehicle", "VehicleClass_VehicleClass_Id", "dbo.VehicleClass");
            DropForeignKey("dbo.VehicleTransponder", "Transponder_Transponder_Id", "dbo.Transponder");
            DropForeignKey("dbo.VehicleTransponder", "Vehicle_PlateNumber", "dbo.Vehicle");
            DropIndex("dbo.VehicleClassVehicle", new[] { "Vehicle_PlateNumber" });
            DropIndex("dbo.VehicleClassVehicle", new[] { "VehicleClass_VehicleClass_Id" });
            DropIndex("dbo.VehicleTransponder", new[] { "Transponder_Transponder_Id" });
            DropIndex("dbo.VehicleTransponder", new[] { "Vehicle_PlateNumber" });
            DropIndex("dbo.Transaction", new[] { "Transponder_Transponder_Id" });
            DropIndex("dbo.Transaction", new[] { "PlateNumber" });
            DropTable("dbo.VehicleClassVehicle");
            DropTable("dbo.VehicleTransponder");
            DropTable("dbo.VehicleClass");
            DropTable("dbo.Vehicle");
            DropTable("dbo.Transponder");
            DropTable("dbo.Transaction");
        }
    }
}
