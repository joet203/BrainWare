using System.Data.Common;

namespace Web.Infrastructure.Repositories
{

    public class OrderRepository
    {
        public DbDataReader GetOrders()
        {
            var database = new Database();

            // Get the orders
            var sql1 =
                "SELECT c.name, o.description, o.order_id FROM company c INNER JOIN [order] o on c.company_id=o.company_id";

            return database.ExecuteReader(sql1);
        }

        public DbDataReader GetOrderProducts()
        {
            var database = new Database();

            //Get the order products
            var sql2 =
                "SELECT op.price, op.order_id, op.product_id, op.quantity, p.name, p.price FROM orderproduct op INNER JOIN product p on op.product_id=p.product_id";

            return database.ExecuteReader(sql2);
        }
    }
}
