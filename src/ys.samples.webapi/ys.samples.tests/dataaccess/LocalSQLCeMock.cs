using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using ys.samples.mocks;
using ys.samples.shared;
using ys.samples.devunion.persistence;

namespace ys.samples.dataaccess {
    public class LocalSQLCeMock : AutofacMockBase {
        private class LocalConnectionStringTracker : ConnectionStringTracker {
            public override string getConnectionString( ) {
                return @"Data Source=data\ys.samples.devunion.sdf;";
            }
            public override bool shouldCreateSchema( ) {
                return true;
            }
        }
        public LocalSQLCeMock(): base("autofac.devunion.json") {

        }
        protected override void registerComponents( ContainerBuilder builder ) {
            builder.RegisterType<LocalConnectionStringTracker>().As<ConnectionStringTracker>().SingleInstance();
        }
    }
}
