namespace CodeFirst.ReverseEngineered.PowerTools.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EnrollmentDateRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Student", "EnrollmentDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Student", "EnrollmentDate", c => c.DateTime());
        }
    }
}
