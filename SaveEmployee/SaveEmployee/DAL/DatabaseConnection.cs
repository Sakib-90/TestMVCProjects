namespace UniversityApplication.DAL
{
    public class DatabaseConnection
    {
        private string connection;

        public string Connection 
        {
            get { return connection; }
            set {connection =
                @"Server=.\SQLEXPRESS2; Database = UniversityApplicationDatabase; Integrated Security=true;"; }
        }
        
    }
}