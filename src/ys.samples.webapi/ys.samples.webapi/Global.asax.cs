using Autofac;
using Autofac.Configuration;
using Autofac.Integration.WebApi;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using ys.samples.ioc;

namespace ys.samples.webapi {
    public class WebApiApplication : System.Web.HttpApplication {
        protected void Application_Start( ) {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            setupAutofac();
        }
        private void setupAutofac( ) {
            var builder = new ContainerBuilder();

            var globalConfig = GlobalConfiguration.Configuration;
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterWebApiFilterProvider(globalConfig);

            var config = new ConfigurationBuilder();
            config.AddJsonFile("autofac.json");
            var module = new ConfigurationModule(config.Build());

            builder.RegisterModule(module);

            var container = builder.Build();
            globalConfig.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            var moduleSetups = container.Resolve<IEnumerable<IModuleSetup>>();
            foreach ( var setup in moduleSetups ) {
                setup.setupModule(container);
            }
        }
    }
}
