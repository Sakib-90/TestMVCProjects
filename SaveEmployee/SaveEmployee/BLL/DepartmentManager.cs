using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SaveEmployee.DAL;
using UniversityApplication.Models;

namespace SaveEmployee.BLL
{
    public class DepartmentManager
    {
        DepartmentGateway gateway = new DepartmentGateway();
        public List<Department> GetDepartments()
        {
            return gateway.GetDepartments();
        }
    }
}