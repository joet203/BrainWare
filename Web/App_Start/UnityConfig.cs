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

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IOrderService, OrderService>();
            container.RegisterType<IOrderRepository, OrderRepository>();
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}