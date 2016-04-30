using System.Collections.Generic;
using System.Data.SqlClient;

namespace UniversityApplication.DAL
{
    public class RoomGateway : DatabaseConnection
    {
        //SqlConnection connection = new SqlConnection(@"Server=.\SQLEXPRESS2; Database = UniversityApplicationDatabase; Integrated Security=true;");
        public List<string> GetRooms()
        {
            SqlConnection connection = new SqlConnection(Connection);

            List<string> roomList = new List<string>();

            string query = "SELECT * FROM Rooms";

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                string room = reader["RoomNo"].ToString();

                roomList.Add(room);
            }

            connection.Close();

            return roomList;
        }
    }
}