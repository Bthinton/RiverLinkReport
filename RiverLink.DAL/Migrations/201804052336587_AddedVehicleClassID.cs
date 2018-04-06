namespace RiverLink.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedVehicleClassID : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Transaction", "VehicleClass_Id", c => c.Short(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Transaction", "VehicleClass_Id");
        }
    }
}
