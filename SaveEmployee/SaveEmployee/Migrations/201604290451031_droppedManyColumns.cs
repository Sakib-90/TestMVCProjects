namespace UniversityApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class droppedManyColumns : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Classrooms",
                c => new
                    {
                        ClassRoomRoomNo = c.String(nullable: false, maxLength: 128),
                        ClassRoomDepartmentCode = c.String(),
                        ClassRoomCourseCode = c.String(),
                        ClassRoomWeekDay = c.String(),
                        ClassRoomStartsAt = c.Time(nullable: false, precision: 7),
                        ClassRoomEndssAt = c.Time(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.ClassRoomRoomNo);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        CourseCode = c.String(nullable: false, maxLength: 50),
                        CourseName = c.String(nullable: false),
                        CourseCredit = c.Double(nullable: false),
                        CourseDescription = c.String(),
                        CourseDepartmentCode = c.String(),
                        CourseSemester = c.String(),
                    })
                .PrimaryKey(t => t.CourseCode);
            
            CreateTable(
                "dbo.CourseStudents",
                c => new
                    {
                        CourseStudentID = c.Int(nullable: false, identity: true),
                        CourseStudentRegNo = c.String(),
                        CourseStudentCourse = c.String(),
                        CourseStudentRegDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CourseStudentID);
            
            CreateTable(
                "dbo.CourseTeachers",
                c => new
                    {
                        CourseTeacherID = c.Int(nullable: false, identity: true),
                        CourseTeacherDepartmentCode = c.String(),
                        CourseTeacherEmail = c.String(),
                    })
                .PrimaryKey(t => t.CourseTeacherID);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        DepartmentCode = c.String(nullable: false, maxLength: 7),
                        DepartmentName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.DepartmentCode);
            
            CreateTable(
                "dbo.StudentResults",
                c => new
                    {
                        StudentResultRegNo = c.String(nullable: false, maxLength: 128),
                        StudentResultCourse = c.String(),
                        StudentResultGrade = c.String(),
                    })
                .PrimaryKey(t => t.StudentResultRegNo);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentRegNo = c.String(nullable: false, maxLength: 128),
                        StudentName = c.String(),
                        StudentContact = c.String(),
                        StudentAddress = c.String(),
                        StudentDepartmentCode = c.String(),
                        StudentEmail = c.String(nullable: false),
                        StudeRegDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.StudentRegNo);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        TeacherEmail = c.String(nullable: false, maxLength: 128),
                        TeacherDesignation = c.String(),
                        TeacherCredit = c.Double(nullable: false),
                        TeacherName = c.String(),
                        TeacherContact = c.String(),
                        TeacherAddress = c.String(),
                        TeacherDepartmentCode = c.String(),
                    })
                .PrimaryKey(t => t.TeacherEmail);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Teachers");
            DropTable("dbo.Students");
            DropTable("dbo.StudentResults");
            DropTable("dbo.Departments");
            DropTable("dbo.CourseTeachers");
            DropTable("dbo.CourseStudents");
            DropTable("dbo.Courses");
            DropTable("dbo.Classrooms");
        }
    }
}
