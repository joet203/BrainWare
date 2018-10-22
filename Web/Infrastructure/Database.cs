using System.Data.Common;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace Web.Infrastructure
{
    public class Database
    {
        private readonly SqlConnection _connection;

        public Database()
        {
            _connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["localdb"].ConnectionString);

            _connection.Open();
        }


        public DbDataReader ExecuteReader(string query)
        {
           

            var sqlQuery = new SqlCommand(query, _connection);

            return sqlQuery.ExecuteReader();
        }

        public int ExecuteNonQuery(string query)
        {
            var sqlQuery = new SqlCommand(query, _connection);

            return sqlQuery.ExecuteNonQuery();
        }

    }
}