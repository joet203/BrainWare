using Microsoft.VisualStudio.TestTools.UnitTesting;
using Web.Infrastructure;
using Web.Infrastructure.Repositories;
namespace Tests.Repositories
{
    [TestClass]
    public class OrderRepositoryTest
    {
        private IOrderRepository _orderRepository;
        public IOrderRepository OrderRepository
        {
            get
            {
                if (_orderRepository == null)
                {
                    return _orderRepository = new OrderRepository(new DatabaseContext());
                }
                return _orderRepository;
            }
        }

        [TestMethod]
        public void OrderRepository_GetOrdersByCompanyId_MustReturnCorrectNumberOfOrders()
        {
            const int companyId = 1;
            const int numberOfOrders = 3;

            var orders = OrderRepository.GetOrdersByCompany(companyId);

            Assert.IsTrue(orders.Count == numberOfOrders, 
                          "Expected " + numberOfOrders.ToString() + " orders for company " + companyId + 
                          ", but found " + orders.Count.ToString());
        }
    }
}