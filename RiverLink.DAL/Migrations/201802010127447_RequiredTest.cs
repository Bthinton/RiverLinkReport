namespace RiverLink.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RequiredTest : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Vehicle", "PlateNumber", c => c.String(maxLength: 20));
            AlterColumn("dbo.Vehicle", "VehicleState", c => c.String(maxLength: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Vehicle", "VehicleState", c => c.String(nullable: false, maxLength: 2));
            AlterColumn("dbo.Vehicle", "PlateNumber", c => c.String(nullable: false, maxLength: 20));
        }
    }
}
