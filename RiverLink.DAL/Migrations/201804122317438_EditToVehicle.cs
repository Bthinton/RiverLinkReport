namespace RiverLink.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditToVehicle : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Transponder", "TransponderStatus");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Transponder", "TransponderStatus", c => c.String());
        }
    }
}
