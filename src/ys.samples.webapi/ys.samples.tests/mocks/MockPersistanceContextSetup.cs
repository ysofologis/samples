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
using ys.samples.infrastructure.persistance;
using ys.samples.shared;

namespace ys.samples.mocks {
    public class MockPersistanceContextSetup : AutofacMockBase {
        private ILifetimeScope rootScope {
            get;
            set;
        }
        public MockPersistanceContextSetup( ) : base("autofac.json") {
        }
        protected override void registerComponents( ContainerBuilder builder ) {
            builder.RegisterType<InMemoryPersistentContext>().As<InfraPersistenceContext>().InstancePerLifetimeScope();
        }
    }
}
