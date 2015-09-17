namespace CodeFirst.ReverseEngineered.PowerTools.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Timestamp : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Person", "Timestamp", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Person", "Timestamp");
        }
    }
}
