using Microsoft.VisualStudio.TestTools.UnitTesting;
using Web.Infrastructure;
using Web.Infrastructure.Repositories;
namespace Tests.Repositories
{
    [TestClass]
    public class OrderRepositoryTest
    {
        private Database _db { get; set; }
        private IOrderRepository _orderRepository;
        public IOrderRepository OrderRepository
        {
            get
            {
                if (_orderRepository == null)
                {
                    return _orderRepository = new OrderRepository();
                }
                return _orderRepository;
            }
        }

        [TestInitialize]
        public void Setup()
        {
            _db = new Database();
        }

        [TestMethod]
        public void OrderRepository_GetOrdersByCompanyId_MustReturn3Orders()
        {
            const int companyId = 1;

            var orders = OrderRepository.GetOrdersByCompany(companyId);

            Assert.IsTrue(orders.Count == 3);
        }
    }
}