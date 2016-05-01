namespace UniversityApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRequiredFieldToCourseAndSemester : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Courses", "CourseDepartmentCode", c => c.String(nullable: false));
            AlterColumn("dbo.Courses", "CourseSemester", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Courses", "CourseSemester", c => c.String());
            AlterColumn("dbo.Courses", "CourseDepartmentCode", c => c.String());
        }
    }
}
