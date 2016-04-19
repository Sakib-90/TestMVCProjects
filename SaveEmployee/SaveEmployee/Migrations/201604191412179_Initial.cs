namespace SaveEmployee.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Code = c.String(nullable: false, maxLength: 7),
                        Name = c.String(nullable: false),
                        Credit = c.Double(nullable: false),
                        Description = c.String(),
                        Department = c.String(),
                        Semester = c.String(),
                    })
                .PrimaryKey(t => t.Code);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        Code = c.String(nullable: false, maxLength: 7),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Code);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Departments");
            DropTable("dbo.Courses");
        }
    }
}
