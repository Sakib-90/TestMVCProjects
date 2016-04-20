using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityApplication.Models;

namespace SaveEmployee.DAL
{
    public class DepartmentGateway
    {
        SqlConnection connection = new SqlConnection(@"Server=.\SQLEXPRESS2; Database = UniversityApplicationDatabase; Integrated Security=true;");
        public List<Department> GetDepartments()
        {
            List<Department> departmentList = new List<Department>();

            string query = "SELECT * FROM Departments ORDER BY Name";

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                string Name = reader["Name"].ToString();
                string code = reader["code"].ToString();
                Department aDepartment = new Department();

                aDepartment.Name = Name;
                aDepartment.Code = code;

                departmentList.Add(aDepartment);
            }

            connection.Close();

            return departmentList;
        }
    }
}