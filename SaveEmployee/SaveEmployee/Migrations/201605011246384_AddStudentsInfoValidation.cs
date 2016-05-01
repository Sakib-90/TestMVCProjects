namespace UniversityApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStudentsInfoValidation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Students", "StudentName", c => c.String(nullable: false));
            AlterColumn("dbo.Students", "StudentContact", c => c.String(nullable: false));
            AlterColumn("dbo.Students", "StudentAddress", c => c.String(nullable: false));
            AlterColumn("dbo.Students", "StudentDepartmentCode", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Students", "StudentDepartmentCode", c => c.String());
            AlterColumn("dbo.Students", "StudentAddress", c => c.String());
            AlterColumn("dbo.Students", "StudentContact", c => c.String());
            AlterColumn("dbo.Students", "StudentName", c => c.String());
        }
    }
}
