namespace UniversityApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTeachersInfoValidation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Teachers", "TeacherName", c => c.String(nullable: false));
            AlterColumn("dbo.Teachers", "TeacherContact", c => c.String(nullable: false));
            AlterColumn("dbo.Teachers", "TeacherAddress", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Teachers", "TeacherAddress", c => c.String());
            AlterColumn("dbo.Teachers", "TeacherContact", c => c.String());
            AlterColumn("dbo.Teachers", "TeacherName", c => c.String());
        }
    }
}
