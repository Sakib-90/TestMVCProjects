namespace UniversityApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ValidationaddedEnrollCourse2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CourseStudents", "CourseStudentRegNo", c => c.String(nullable: false));
            AlterColumn("dbo.CourseStudents", "CourseStudentCourse", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CourseStudents", "CourseStudentCourse", c => c.String());
            AlterColumn("dbo.CourseStudents", "CourseStudentRegNo", c => c.String());
        }
    }
}
