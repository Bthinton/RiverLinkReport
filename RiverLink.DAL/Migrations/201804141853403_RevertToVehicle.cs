namespace RiverLink.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RevertToVehicle : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vehicle", "Classification", c => c.Int(nullable: false));
            AlterColumn("dbo.Vehicle", "VehicleClass", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Vehicle", "VehicleClass", c => c.Int(nullable: false));
            DropColumn("dbo.Vehicle", "Classification");
        }
    }
}
