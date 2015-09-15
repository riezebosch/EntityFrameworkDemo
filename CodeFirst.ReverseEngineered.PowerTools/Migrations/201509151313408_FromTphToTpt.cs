namespace CodeFirst.ReverseEngineered.PowerTools.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FromTphToTpt : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Student",
                c => new
                    {
                        PersonID = c.Int(nullable: false),
                        EnrollmentDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.PersonID)
                .ForeignKey("dbo.Person", t => t.PersonID)
                .Index(t => t.PersonID);

            // Prevent from data loss :)
            Sql("INSERT INTO dbo.Student (PersonID, EnrollmentDate) SELECT PersonID, EnrollmentDate FROM dbo.Person WHERE EnrollmentDate IS NOT NULL");

            DropColumn("dbo.Person", "EnrollmentDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Person", "EnrollmentDate", c => c.DateTime());
            DropForeignKey("dbo.Student", "PersonID", "dbo.Person");
            DropIndex("dbo.Student", new[] { "PersonID" });
            DropTable("dbo.Student");
        }
    }
}
