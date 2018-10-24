using System.Data.Common;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace Web.Infrastructure
{
    public class Database
    {
        private readonly SqlConnection _connection;
        public readonly string connectionString;
        public Database()
        {
            connectionString = WebConfigurationManager.ConnectionStrings["localdb"].ConnectionString;
        }


        public DbDataReader ExecuteReader(SqlCommand query)
        {
            SqlDataReader ret;
            SqlConnection connection = new SqlConnection(connectionString);
            
            connection.Open();
            query.Connection = connection;
            ret = query.ExecuteReader();
            
            return ret;
        }

        public int ExecuteNonQuery(SqlCommand query)
        {
            int ret;
            SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();
            ret = query.ExecuteNonQuery();

            return ret;
        }

    }
}