using Autofac;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ys.samples.dataaccess;
using ys.samples.infrastructure.persistance;
using ys.samples.ioc;

namespace ys.samples.infrastructure {
    internal class Module : Autofac.Module {
        protected override void Load( ContainerBuilder builder ) {
            base.Load(builder);
            builder.RegisterType<InfraDBContext>().InstancePerLifetimeScope();
            builder.Register( c => new InternalPersistenceContext( c.Resolve<InfraDBContext>() ) ).As<InfraPersistenceContext>().InstancePerLifetimeScope();
            builder.RegisterType<ModuleSetup>().As<IModuleSetup>().SingleInstance();
        }
    }
    [Export(typeof(IModuleProber))]
    public class ModuleProber : IModuleProber {
        public Autofac.Module Module {
            get;
            private set;
        }
        public ModuleProber( ) {
            this.Module = new Module();
        }
        public Autofac.Module GetModule( ) {
            return this.Module;
        }
    }

}
