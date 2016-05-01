namespace UniversityApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTeachersDesignationValidation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Teachers", "TeacherDesignation", c => c.String(nullable: false));
            AlterColumn("dbo.Teachers", "TeacherDepartmentCode", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Teachers", "TeacherDepartmentCode", c => c.String());
            AlterColumn("dbo.Teachers", "TeacherDesignation", c => c.String());
        }
    }
}
