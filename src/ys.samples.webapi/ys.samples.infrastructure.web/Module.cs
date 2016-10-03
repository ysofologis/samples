using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Autofac.Integration.WebApi;

namespace ys.samples.infrastructure {
    internal class Module : Autofac.Module {
        protected override void Load( ContainerBuilder builder ) {
            base.Load(builder);
            builder.RegisterApiControllers().PropertiesAutowired();
        }
    }
}
