using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using ys.samples.devunion.companies;
using ys.samples.ioc;
using System.ComponentModel.Composition;

namespace ys.samples.devunion {
    public class Exports : Autofac.Module{
        protected override void Load( ContainerBuilder builder ) {
            base.Load(builder);
            builder.RegisterType<CompanyRepository>().InstancePerDependency();
            builder.RegisterType<CompanyService>().As<ICompanyService>().InstancePerDependency().PropertiesAutowired();
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
