using Autofac;
using Autofac.Configuration;
using Autofac.Integration.WebApi;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Configuration;
using System.IO;
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
        private class PartComposer {
            [ImportMany(typeof(IModuleProber))]
            public IEnumerable<IModuleProber> moduleProbers {
                get;
                set;
            }
        }
        private void loadPluggins( ContainerBuilder builder ) {
            var currentDir = new DirectoryInfo(Path.GetDirectoryName(typeof(Paging).Assembly.EscapedCodeBase.Replace("file:///", ""))).Parent.FullName;
            var libDir = Path.Combine(currentDir, "lib");
            var dirCatalog = new DirectoryCatalog(libDir, "*.dll");
            var aggregateCatalog = new AggregateCatalog();
            aggregateCatalog.Catalogs.Add(dirCatalog);
            using ( CompositionContainer mefContainer = new CompositionContainer(aggregateCatalog) ) {
                var partComposer = new PartComposer();
                mefContainer.ComposeParts(partComposer);
                foreach ( var prober in partComposer.moduleProbers ) {
                    var autofacModule = prober.GetModule();
                    builder.RegisterModule(autofacModule);
                }
            }
        }
        private void setupAutofac( ) {
            var builder = new ContainerBuilder();

            var domainPath = AppDomain.CurrentDomain.BaseDirectory;

            var globalConfig = GlobalConfiguration.Configuration;
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterWebApiFilterProvider(globalConfig);

            var config = new ConfigurationBuilder();
            config.AddJsonFile("conf/autofac.json");
            var module = new ConfigurationModule(config.Build());

            builder.RegisterModule(module);
            loadPluggins(builder);

            var container = builder.Build();
            globalConfig.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            var moduleSetups = container.Resolve<IEnumerable<IModuleSetup>>();
            foreach ( var setup in moduleSetups ) {
                setup.setupModule(container);
            }
        }
    }
}
