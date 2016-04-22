using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityApplication.Models;

namespace UniversityApplication.DAL
{
    public class CourseGateway
    {
        SqlConnection connection = new SqlConnection(@"Server=.\SQLEXPRESS2; Database = UniversityApplicationDatabase; Integrated Security=true;");
        public List<Course> GetCourses()
        {
            List<Course> courseListList = new List<Course>();

            string query = "SELECT * FROM Courses ORDER BY Name";

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                string name = reader["Name"].ToString();
                string code = reader["code"].ToString();
                double credit = Convert.ToDouble(reader["credit"]);
                
                Course aCourse = new Course();

                aCourse.CourseName = name;
                aCourse.CourseCode = code;
                aCourse.CourseCredit = credit;

                courseListList.Add(aCourse);
            }

            connection.Close();

            return courseListList;
        }
    }
}