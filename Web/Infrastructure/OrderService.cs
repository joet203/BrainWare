using System.Collections.Generic;
using System.Data;
using Web.Infrastructure.Repositories;
using Web.Models;

namespace Web.Infrastructure
{
    public class OrderService
    {
        private OrderRepository _orderRepo
        { get; set; }
        
        public OrderService(OrderRepository orderRepo)
        {
            _orderRepo = orderRepo;
        }
        public List<Order> GetOrdersForCompany(int CompanyId)
        {
            //Get the orders
            var reader1 = _orderRepo.GetOrders();

            var values = new List<Order>();
            
            while (reader1.Read())
            {
                var record1 = (IDataRecord) reader1;

                values.Add(new Order()
                {
                    CompanyName = record1.GetString(0),
                    Description = record1.GetString(1),
                    OrderId = record1.GetInt32(2),
                    OrderProducts = new List<OrderProduct>()
                });

            }

            reader1.Close();

            //Get the order products
            var reader2 = _orderRepo.GetOrderProducts();

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

            values = SetOrderProductsAndTotals(values, values2);

            return values;
        }

        private List<Order> SetOrderProductsAndTotals(List<Order> orders, List<OrderProduct> orderProducts)
        {
            foreach (var order in orders)
            {
                foreach (var orderproduct in orderProducts)
                {
                    if (orderproduct.OrderId != order.OrderId)
                        continue;

                    order.OrderProducts.Add(orderproduct);
                    order.OrderTotal = order.OrderTotal + (orderproduct.Price * orderproduct.Quantity);
                }
            }
            return orders;
        }
    }
}