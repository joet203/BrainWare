using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Web.Models;

namespace Web.Infrastructure.Repositories
{

    public class OrderRepository : IOrderRepository
    {
        private Database _db;
        public OrderRepository()
        {
            _db = new Database();
        }
        public IList<Order> GetOrdersByCompany(int companyId)
        {
            // Get the orders
            SqlCommand orderQuery = new SqlCommand();
            orderQuery.CommandText = "SELECT c.name, o.description, o.order_id FROM company c INNER JOIN [order] o ON c.company_id=o.company_id " +
                " WHERE c.company_id = @CompanyId ";
            orderQuery.Parameters.AddWithValue("@CompanyId", companyId);

            var reader1 = _db.ExecuteReader(orderQuery);

            var values = new List<Order>();

            while (reader1.Read())
            {
                var record1 = (IDataRecord)reader1;

                values.Add(new Order()
                {
                    CompanyName = record1.GetString(0),
                    Description = record1.GetString(1),
                    OrderId = record1.GetInt32(2),
                    OrderProducts = new List<OrderProduct>()
                });

            }

            reader1.Close();
            return values;
        }

        public IList<OrderProduct> GetOrderProducts()
        {
            SqlCommand productQuery = new SqlCommand();
            //Get the order products
            productQuery.CommandText =
                "SELECT op.price, op.order_id, op.product_id, op.quantity, p.name, p.price FROM orderproduct op INNER JOIN product p on op.product_id=p.product_id";

            var reader2 = _db.ExecuteReader(productQuery);
            var values2 = new List<OrderProduct>();

            while (reader2.Read())
            {
                var record2 = (IDataRecord)reader2;

                values2.Add(new OrderProduct()
                {
                    OrderId = record2.GetInt32(1),
                    ProductId = record2.GetInt32(2),
                    Price = record2.GetDecimal(0),
                    Quantity = record2.GetInt32(3),
                    Product = new Product()
                    {
                        Name = record2.GetString(4),
                        Price = record2.GetDecimal(5)
                    }
                });
            }

            reader2.Close();
            return values2;
        }
    }
}
