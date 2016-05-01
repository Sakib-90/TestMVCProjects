namespace UniversityApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedCourseTeacher : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CourseTeachers", "CourseTeacherCourseCode", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CourseTeachers", "CourseTeacherCourseCode");
        }
    }
}
