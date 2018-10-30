using System.Web.Http;
using Unity;
using Unity.WebApi;
using Web.Infrastructure;
using Web.Infrastructure.Repositories;

namespace Web
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            container.RegisterType<IOrderService, OrderService>();
            container.RegisterType<IOrderRepository, OrderRepository>();
            container.RegisterType<IDatabaseContext, DatabaseContext>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}