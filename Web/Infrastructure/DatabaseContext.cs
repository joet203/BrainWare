using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace Web.Infrastructure
{
    public class DatabaseContext : IDatabaseContext
    {
        public readonly string connectionString;
        public DatabaseContext()
        {
            connectionString = WebConfigurationManager.ConnectionStrings["localdb"].ConnectionString;
        }


        public DataTable ExecuteDataTable(SqlCommand query)
        {
            DataTable ret = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                query.Connection = connection;
                ret.Load(query.ExecuteReader());
            }
            return ret;
        }

    }
}