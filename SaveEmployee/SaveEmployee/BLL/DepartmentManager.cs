using System.Collections.Generic;
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