using System.Collections.Generic;
using System.Data.Common;
using Web.Models;

namespace Web.Infrastructure.Repositories
{
    public interface IOrderRepository
    {
        IList<Order> GetOrdersByCompany(int companyId);
        IList<OrderProduct> GetOrderProducts();
    }
}
