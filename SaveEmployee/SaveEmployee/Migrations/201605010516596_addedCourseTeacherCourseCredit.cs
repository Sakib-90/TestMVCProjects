namespace UniversityApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedCourseTeacherCourseCredit : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CourseTeachers", "CourseTeacherCourseCredit", c => c.Double());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CourseTeachers", "CourseTeacherCourseCredit");
        }
    }
}
