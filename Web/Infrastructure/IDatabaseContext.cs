using System.Data;
using System.Data.SqlClient;
namespace Web.Infrastructure
{
    public interface IDatabaseContext
    {
        DataTable ExecuteDataTable(SqlCommand query);
    }
}
