using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Web.Models;

namespace Web.Infrastructure.Repositories
{

    public class OrderRepository : IOrderRepository
    {
        private IDatabaseContext _db;
        public OrderRepository(IDatabaseContext db)
        {
            _db = db;
        }
        public IList<Order> GetOrdersByCompany(int companyId)
        {
            // Get the orders
            SqlCommand orderQuery = new SqlCommand();
            orderQuery.CommandText = " SELECT c.name, o.description, o.order_id " +
                                     " FROM company c INNER JOIN [order] o ON c.company_id=o.company_id " +
                                     " WHERE c.company_id = @CompanyId ";
            orderQuery.Parameters.AddWithValue("@CompanyId", companyId);

            var dt1 = _db.ExecuteDataTable(orderQuery);

            var values = new List<Order>();

            foreach(DataRow dr in dt1.Rows)
            {
                values.Add(new Order()
                {
                    CompanyName = dr[0].ToString(),
                    Description = dr[1].ToString(),
                    OrderId = Convert.ToInt32(dr[2]),
                    OrderProducts = new List<OrderProduct>()
                });

            }
            return values;
        }

        public IList<OrderProduct> GetOrderProducts()
        {
            SqlCommand productQuery = new SqlCommand();
            //Get the order products
            productQuery.CommandText =
                " SELECT op.price, op.order_id, op.product_id, op.quantity, p.name, p.price " +
                " FROM orderproduct op INNER JOIN product p on op.product_id=p.product_id";

            var dt2 = _db.ExecuteDataTable(productQuery);
            var values2 = new List<OrderProduct>();

            foreach(DataRow dr in dt2.Rows)
            {
                values2.Add(new OrderProduct()
                {
                    OrderId = Convert.ToInt32(dr[1]),
                    ProductId = Convert.ToInt32(dr[2]),
                    Price = Convert.ToDecimal(dr[0]),
                    Quantity = Convert.ToInt32(dr[3]),
                    Product = new Product()
                    {
                        Name = dr[4].ToString(),
                        Price = Convert.ToDecimal(dr[5])
                    }
                });
            }

            return values2;
        }
    }
}
