namespace RiverLink.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeToDataFiles : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Transponder", "PlateNumber", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Transponder", "PlateNumber");
        }
    }
}
