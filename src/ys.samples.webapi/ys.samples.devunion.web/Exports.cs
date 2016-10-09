using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Autofac.Integration.WebApi;
using ys.samples.ioc;
using System.ComponentModel.Composition;

namespace ys.samples.devunion {
    public class Exports1 : Autofac.Module {
        protected override void Load( ContainerBuilder builder ) {
            base.Load(builder);
            builder.RegisterApiControllers(ThisAssembly).PropertiesAutowired();
        }
    }
    [Export(typeof(IModuleProber))]
    public class ModuleProber : IModuleProber {
        public Autofac.Module Module {
            get;
            private set;
        }
        public ModuleProber( ) {
            this.Module = new Exports1();
        }
        public Autofac.Module GetModule( ) {
            return this.Module;
        }
    }

}
