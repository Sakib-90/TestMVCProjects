﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityApplication.Models;

namespace SaveEmployee.DAL
{
    public class SemesterGateway
    {
        SqlConnection connection = new SqlConnection(@"Server=.\SQLEXPRESS2; Database = UniversityApplicationDatabase; Integrated Security=true;");
        public List<string> GetSemester()
        {
            List<string> semesterList = new List<string>();

            string query = "SELECT * FROM Semester";

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                string semester = reader["Semester"].ToString();
                
                //Department aDepartment = new Department();

                //aDepartment.Name = Name;
                //aDepartment.Code = code;

                semesterList.Add(semester);
            }

            connection.Close();

            return semesterList;
        }
    }
}