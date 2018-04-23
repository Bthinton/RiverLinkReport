namespace RiverLink.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SwitchedVehDataToVehicle : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.VehicleClassVehicle", "VehicleClass_VehicleClass_Id", "dbo.VehicleClass");
            DropForeignKey("dbo.VehicleClassVehicle", "Vehicle_Vehicle_Id", "dbo.Vehicle");
            DropIndex("dbo.VehicleClassVehicle", new[] { "VehicleClass_VehicleClass_Id" });
            DropIndex("dbo.VehicleClassVehicle", new[] { "Vehicle_Vehicle_Id" });
            AddColumn("dbo.Vehicle", "VehicleClass", c => c.String());
            AddColumn("dbo.Vehicle", "Classification", c => c.Int(nullable: false));
            AddColumn("dbo.Vehicle", "VehicleClass_VehicleClass_Id", c => c.Short());
            CreateIndex("dbo.Vehicle", "VehicleClass_VehicleClass_Id");
            AddForeignKey("dbo.Vehicle", "VehicleClass_VehicleClass_Id", "dbo.VehicleClass", "VehicleClass_Id");
            DropTable("dbo.VehicleData");
            DropTable("dbo.VehicleClassVehicle");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.VehicleClassVehicle",
                c => new
                    {
                        VehicleClass_VehicleClass_Id = c.Short(nullable: false),
                        Vehicle_Vehicle_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.VehicleClass_VehicleClass_Id, t.Vehicle_Vehicle_Id });
            
            CreateTable(
                "dbo.VehicleData",
                c => new
                    {
                        Vehicle_Id = c.Int(nullable: false, identity: true),
                        PlateNumber = c.String(maxLength: 20),
                        Make = c.String(maxLength: 32),
                        Model = c.String(maxLength: 32),
                        Year = c.Int(nullable: false),
                        VehicleState = c.String(maxLength: 2),
                        VehicleStatus = c.String(),
                        VehicleClass = c.String(),
                        Classification = c.Int(nullable: false),
                        Transponder = c.String(),
                        TransponderType = c.String(),
                    })
                .PrimaryKey(t => t.Vehicle_Id);
            
            DropForeignKey("dbo.Vehicle", "VehicleClass_VehicleClass_Id", "dbo.VehicleClass");
            DropIndex("dbo.Vehicle", new[] { "VehicleClass_VehicleClass_Id" });
            DropColumn("dbo.Vehicle", "VehicleClass_VehicleClass_Id");
            DropColumn("dbo.Vehicle", "Classification");
            DropColumn("dbo.Vehicle", "VehicleClass");
            CreateIndex("dbo.VehicleClassVehicle", "Vehicle_Vehicle_Id");
            CreateIndex("dbo.VehicleClassVehicle", "VehicleClass_VehicleClass_Id");
            AddForeignKey("dbo.VehicleClassVehicle", "Vehicle_Vehicle_Id", "dbo.Vehicle", "Vehicle_Id", cascadeDelete: true);
            AddForeignKey("dbo.VehicleClassVehicle", "VehicleClass_VehicleClass_Id", "dbo.VehicleClass", "VehicleClass_Id", cascadeDelete: true);
        }
    }
}
