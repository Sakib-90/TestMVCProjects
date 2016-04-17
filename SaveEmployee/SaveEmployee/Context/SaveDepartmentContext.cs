using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using SaveEmployee.Models;

namespace SaveEmployee.Context
{
    public class SaveDepartmentContext : DbContext
    {
        public DbSet<Department> Departments { get; set; }
    }
}