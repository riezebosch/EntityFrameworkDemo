namespace CodeFirst.ReverseEngineered.PowerTools.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Rating : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DemoDatas", "Rating", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DemoDatas", "Rating");
        }
    }
}
