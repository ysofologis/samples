using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using ys.samples.devunion.persistence;
using NHibernate.Engine;
using ys.samples.ioc;

namespace ys.samples.devunion {
    public class Module : Autofac.Module {
        protected override void Load( ContainerBuilder builder ) {
            base.Load(builder);
            builder.RegisterType<PersistenceSetup>().SingleInstance();
            builder.Register<DataContext>( x => new DataContext( x.Resolve<PersistenceSetup>() ) ).As<DevunionPersistenceContext>().InstancePerLifetimeScope();
            builder.RegisterType<ConnectionStringTracker>().As<ConnectionStringTracker>().SingleInstance();

            builder.RegisterType<ModuleSetup>().As<IModuleSetup>().SingleInstance();

        }
    }
}
