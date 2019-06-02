using SPG.DataAccess;
using SPG.DataService.Interfaces;
using SPG.DataService.Services;
using SPG.Domain.Interfaces.Services;
using System.Web.Http;
using Unity;
using Unity.Lifetime;

namespace SPG
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            var container = new UnityContainer();
            container.RegisterType<IMessageService, MessageService>(new HierarchicalLifetimeManager());
            container.RegisterType<IDataAccessService, DataAccessService>(new HierarchicalLifetimeManager());
            config.DependencyResolver = new UnityResolver(container);
        }
    }
}
