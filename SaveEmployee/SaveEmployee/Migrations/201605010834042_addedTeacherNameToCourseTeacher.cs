namespace UniversityApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedTeacherNameToCourseTeacher : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CourseTeachers", "CourseTeacherTeacherName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CourseTeachers", "CourseTeacherTeacherName");
        }
    }
}
