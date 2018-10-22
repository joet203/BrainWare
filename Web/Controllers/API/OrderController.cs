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
        [HttpGet]
        public IEnumerable<Order> GetOrders(int id = 1)
        {
            var data = new OrderService(new OrderRepository());

            return data.GetOrdersForCompany(id);
        }
    }
}
