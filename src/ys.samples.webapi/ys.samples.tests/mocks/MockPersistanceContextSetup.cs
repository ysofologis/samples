using Autofac;
using Autofac.Configuration;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ys.samples.dataaccess;
using ys.samples.shared;

namespace ys.samples.mocks {
    public class MockPersistanceContextSetup : IMockSetup {
        private ILifetimeScope rootScope {
            get;
            set;
        }
        public MockPersistanceContextSetup( ) {
            var builder = new Autofac.ContainerBuilder();
            
            var config = new ConfigurationBuilder();
            config.AddJsonFile("autofac.json");
            var module = new ConfigurationModule(config.Build());
            builder.RegisterModule(module);
            builder.RegisterType<InMemoryPersistentContext>().As<IPersistenceContext>().InstancePerLifetimeScope();

            this.rootScope = builder.Build();
        }
        public ClassT Resolve<ClassT>( ) {
            try {
                return this.rootScope.Resolve<ClassT>();
            } catch(Exception x) {
                Trace.WriteLine(x);
                throw;
            }
        }

        public ILifetimeScope beginMethodScope( ) {
            var scope = this.rootScope.BeginLifetimeScope();
            return scope;
        }
        public void Dispose( ) {
            this.rootScope.Dispose();    
        }
    }
}
