using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using UniversityApplication.Models;

namespace UniversityApplication.Context
{
    public class SaveCourseContext : DbContext
    {
        public DbSet<Course> Courses { get; set; }
    }
}