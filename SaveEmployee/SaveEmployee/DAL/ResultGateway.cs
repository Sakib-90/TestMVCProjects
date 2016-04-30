using System.Collections.Generic;
using System.Data.SqlClient;

namespace UniversityApplication.DAL
{
    public class ResultGateway : DatabaseConnection
    {
        //SqlConnection connection = new SqlConnection(@"Server=.\SQLEXPRESS2; Database = UniversityApplicationDatabase; Integrated Security=true;");
        public List<string> GetResults()
        {
            SqlConnection connection = new SqlConnection(Connection);

            List<string> resultListList = new List<string>();

            string query = "SELECT * FROM Results";

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                string result = reader["Grade"].ToString();

                resultListList.Add(result);
            }

            connection.Close();

            return resultListList;
        }
    }
}