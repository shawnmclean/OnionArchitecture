using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnionArchitecture.Web.Mvc.CompositeRoot
{
    using System.Reflection;
    using System.Web.Http;
    using System.Web.Http.Controllers;

    using OnionArchitecture.Infrastructure.DependencyResolution;
    using OnionArchitecture.Web.Mvc.Filters;

    internal class DependencyConfiguration
    {
        public static void Configure()
        {
            // Create the container as usual.
            var container = Initialize.Register();

            // register Web API controllers (important!)
            var controllerTypes =
                from type in Assembly.GetExecutingAssembly().GetExportedTypes()
                where typeof(IHttpController).IsAssignableFrom(type)
                where !type.IsAbstract
                where !type.IsGenericTypeDefinition
                where type.Name.EndsWith("Controller", StringComparison.Ordinal)
                select type;

            foreach (var controllerType in controllerTypes)
            {
                container.Register(controllerType);
            }

            // Verify the container configuration
            container.Verify();

            // Register the dependency resolver.
            GlobalConfiguration.Configuration.DependencyResolver =
                new SimpleInjectorWebApiDependencyResolver(container);
        }
    }
}