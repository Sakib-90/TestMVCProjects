using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityApplication.Models;

namespace UniversityApplication.DAL
{
    public class TeachersGateway
    {
        SqlConnection connection = new SqlConnection(@"Server=.\SQLEXPRESS2; Database = UniversityApplicationDatabase; Integrated Security=true;");
        public List<Teacher> GetTeachers(string departmentName)
        {
            List<Teacher> teacherList = new List<Teacher>();

            string query = "SELECT * FROM Teachers WHERE Department = '"+departmentName+"'ORDER BY Name";

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                string name = reader["Name"].ToString();
                double credit = Convert.ToDouble(reader["Credit"]);
                
                Teacher aTeacher = new Teacher();

                aTeacher.Name = name;
                aTeacher.Credit = credit;

                teacherList.Add(aTeacher);
            }

            connection.Close();

            return teacherList;
        }
    }
}