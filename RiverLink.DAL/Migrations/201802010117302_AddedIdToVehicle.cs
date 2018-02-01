namespace RiverLink.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedIdToVehicle : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Transaction", "PlateNumber", "dbo.Vehicle");
            DropForeignKey("dbo.VehicleTransponder", "Vehicle_PlateNumber", "dbo.Vehicle");
            DropForeignKey("dbo.VehicleClassVehicle", "Vehicle_PlateNumber", "dbo.Vehicle");
            DropIndex("dbo.Transaction", new[] { "PlateNumber" });
            DropIndex("dbo.VehicleTransponder", new[] { "Vehicle_PlateNumber" });
            DropIndex("dbo.VehicleClassVehicle", new[] { "Vehicle_PlateNumber" });
            RenameColumn(table: "dbo.VehicleTransponder", name: "Vehicle_PlateNumber", newName: "Vehicle_Vehicle_Id");
            RenameColumn(table: "dbo.VehicleClassVehicle", name: "Vehicle_PlateNumber", newName: "Vehicle_Vehicle_Id");
            DropPrimaryKey("dbo.Vehicle");
            DropPrimaryKey("dbo.VehicleTransponder");
            DropPrimaryKey("dbo.VehicleClassVehicle");
            AddColumn("dbo.Transaction", "Vehicle_Vehicle_Id", c => c.Int(nullable: false));
            AddColumn("dbo.Vehicle", "Vehicle_Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Transaction", "PlateNumber", c => c.String(maxLength: 20));
            AlterColumn("dbo.VehicleTransponder", "Vehicle_Vehicle_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.VehicleClassVehicle", "Vehicle_Vehicle_Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Vehicle", "Vehicle_Id");
            AddPrimaryKey("dbo.VehicleTransponder", new[] { "Vehicle_Vehicle_Id", "Transponder_Transponder_Id" });
            AddPrimaryKey("dbo.VehicleClassVehicle", new[] { "VehicleClass_VehicleClass_Id", "Vehicle_Vehicle_Id" });
            CreateIndex("dbo.Transaction", "Vehicle_Vehicle_Id");
            CreateIndex("dbo.VehicleTransponder", "Vehicle_Vehicle_Id");
            CreateIndex("dbo.VehicleClassVehicle", "Vehicle_Vehicle_Id");
            AddForeignKey("dbo.Transaction", "Vehicle_Vehicle_Id", "dbo.Vehicle", "Vehicle_Id", cascadeDelete: true);
            AddForeignKey("dbo.VehicleTransponder", "Vehicle_Vehicle_Id", "dbo.Vehicle", "Vehicle_Id", cascadeDelete: true);
            AddForeignKey("dbo.VehicleClassVehicle", "Vehicle_Vehicle_Id", "dbo.Vehicle", "Vehicle_Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VehicleClassVehicle", "Vehicle_Vehicle_Id", "dbo.Vehicle");
            DropForeignKey("dbo.VehicleTransponder", "Vehicle_Vehicle_Id", "dbo.Vehicle");
            DropForeignKey("dbo.Transaction", "Vehicle_Vehicle_Id", "dbo.Vehicle");
            DropIndex("dbo.VehicleClassVehicle", new[] { "Vehicle_Vehicle_Id" });
            DropIndex("dbo.VehicleTransponder", new[] { "Vehicle_Vehicle_Id" });
            DropIndex("dbo.Transaction", new[] { "Vehicle_Vehicle_Id" });
            DropPrimaryKey("dbo.VehicleClassVehicle");
            DropPrimaryKey("dbo.VehicleTransponder");
            DropPrimaryKey("dbo.Vehicle");
            AlterColumn("dbo.VehicleClassVehicle", "Vehicle_Vehicle_Id", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.VehicleTransponder", "Vehicle_Vehicle_Id", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Transaction", "PlateNumber", c => c.String(nullable: false, maxLength: 20));
            DropColumn("dbo.Vehicle", "Vehicle_Id");
            DropColumn("dbo.Transaction", "Vehicle_Vehicle_Id");
            AddPrimaryKey("dbo.VehicleClassVehicle", new[] { "VehicleClass_VehicleClass_Id", "Vehicle_PlateNumber" });
            AddPrimaryKey("dbo.VehicleTransponder", new[] { "Vehicle_PlateNumber", "Transponder_Transponder_Id" });
            AddPrimaryKey("dbo.Vehicle", "PlateNumber");
            RenameColumn(table: "dbo.VehicleClassVehicle", name: "Vehicle_Vehicle_Id", newName: "Vehicle_PlateNumber");
            RenameColumn(table: "dbo.VehicleTransponder", name: "Vehicle_Vehicle_Id", newName: "Vehicle_PlateNumber");
            CreateIndex("dbo.VehicleClassVehicle", "Vehicle_PlateNumber");
            CreateIndex("dbo.VehicleTransponder", "Vehicle_PlateNumber");
            CreateIndex("dbo.Transaction", "PlateNumber");
            AddForeignKey("dbo.VehicleClassVehicle", "Vehicle_PlateNumber", "dbo.Vehicle", "PlateNumber", cascadeDelete: true);
            AddForeignKey("dbo.VehicleTransponder", "Vehicle_PlateNumber", "dbo.Vehicle", "PlateNumber", cascadeDelete: true);
            AddForeignKey("dbo.Transaction", "PlateNumber", "dbo.Vehicle", "PlateNumber", cascadeDelete: true);
        }
    }
}
