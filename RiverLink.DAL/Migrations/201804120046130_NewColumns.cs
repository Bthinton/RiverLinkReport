namespace RiverLink.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewColumns : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Transponder", "TransponderNumber", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Transponder", "TransponderNumber");
        }
    }
}
