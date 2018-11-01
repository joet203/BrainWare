using Microsoft.VisualStudio.TestTools.UnitTesting;
using Web.Infrastructure;
using Web.Infrastructure.Repositories;

namespace Tests.Services
{
    [TestClass]
    public class OrderServiceTests
    {
        private IOrderService _orderService;
        public IOrderService OrderService
        {
            get
            {
                if (_orderService == null)
                {
                    return _orderService = new OrderService(new OrderRepository(new DatabaseContext()));
                }
                return _orderService;
            }
        }

        [TestMethod]
        public void OrderService_SetOrderProductsAndTotalsSetsCorrectValues()
        {

            Assert.IsTrue(true, "tbc"); //tbc
        }
    }
    
}
