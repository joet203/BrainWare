using System.Collections.Generic;
using System.Web.Http;
using Web.Infrastructure;
using Web.Models;
using Web.Infrastructure.Repositories;
using HttpGetAttribute = System.Web.Mvc.HttpGetAttribute;

namespace Web.Controllers
{

    public class OrderController : ApiController
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public IEnumerable<Order> GetOrders(int id = 1)
        {
            return _orderService.GetOrdersForCompany(id);
        }
    }
}
