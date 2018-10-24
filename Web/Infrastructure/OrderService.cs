using System.Collections.Generic;
using System.Data;
using Web.Infrastructure.Repositories;
using Web.Models;

namespace Web.Infrastructure
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepo;
        
        public OrderService(IOrderRepository orderRepo)
        {
            _orderRepo = orderRepo;
        }

        //Retrieve orders for specified company and populate products in orders
        public IList<Order> GetOrdersForCompany(int CompanyId)
        {
            //Get the orders
            var orders = _orderRepo.GetOrdersByCompany(CompanyId);

            //Get the order products
            var products = _orderRepo.GetOrderProducts();

            var values = SetOrderProductsAndTotals(orders, products);

            return values;
        }

        private IList<Order> SetOrderProductsAndTotals(IList<Order> orders, IList<OrderProduct> orderProducts)
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