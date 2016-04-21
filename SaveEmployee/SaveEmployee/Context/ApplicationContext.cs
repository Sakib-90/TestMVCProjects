using System.Data.Entity;
using UniversityApplication.Models;

namespace UniversityApplication.Context
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Teacher> Teachers { get; set; }

        public System.Data.Entity.DbSet<UniversityApplication.Models.CourseTeacher> CourseTeachers { get; set; }
        //public DbSet<CourseTeacher> CoursesTeachers { get; set; }
        
    }
}