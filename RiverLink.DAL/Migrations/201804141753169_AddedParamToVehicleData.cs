namespace RiverLink.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedParamToVehicleData : DbMigration
    {
        public override void Up()
        {
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
            
        }
        
        public override void Down()
        {
            DropTable("dbo.VehicleData");
        }
    }
}
