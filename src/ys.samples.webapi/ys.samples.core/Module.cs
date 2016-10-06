using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using ys.samples.web;

namespace ys.samples {
    public class Module : Autofac.Module {
        protected override void Load( ContainerBuilder builder ) {
            base.Load(builder);
            builder.RegisterType<config.AppSettingConfigService>().As<config.IConfigurationService>().InstancePerDependency();
            builder.RegisterType<DefaultHateoasDecorator>().As<IHateoasDecorator>().InstancePerDependency();
            builder.RegisterType<log.DotNetTraceLogger>().As<log.ILogger>().InstancePerDependency();
        }
    }
}
