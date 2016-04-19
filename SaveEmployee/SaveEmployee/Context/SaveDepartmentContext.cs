using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using UniversityApplication.Models;

namespace UniversityApplication.Context
{
    public class SaveDepartmentContext : DbContext
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Course> Courses { get; set; }
    }
}