namespace UniversityApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewKeyAddedToClassRoom : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Classrooms");
            AddColumn("dbo.Classrooms", "ClassroomId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Classrooms", "ClassRoomRoomNo", c => c.String());
            AddPrimaryKey("dbo.Classrooms", "ClassroomId");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Classrooms");
            AlterColumn("dbo.Classrooms", "ClassRoomRoomNo", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.Classrooms", "ClassroomId");
            AddPrimaryKey("dbo.Classrooms", "ClassRoomRoomNo");
        }
    }
}
