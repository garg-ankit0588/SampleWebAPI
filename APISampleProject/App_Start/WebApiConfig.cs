using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using SimpleInjector;
using APIInfrastructure;
using SimpleInjector.Integration.WebApi;

namespace APISampleProject
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

            var container = new Container();
            container.Register<IGettingEmployees, GetEmployeeDetails>(Lifestyle.Singleton);

            container.Verify();

            GlobalConfiguration.Configuration.DependencyResolver =
        new SimpleInjectorWebApiDependencyResolver(container);
        }
    }
}
