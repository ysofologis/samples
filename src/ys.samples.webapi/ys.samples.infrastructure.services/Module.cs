using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using ys.samples.infrastructure.users;

namespace ys.samples.infrastructure {
    public class Module : Autofac.Module {
        protected override void Load( ContainerBuilder builder ) {
            base.Load(builder);
            builder.RegisterType<UserRepository>().InstancePerDependency();
            builder.RegisterType<UserService>().As<IUserService>().InstancePerDependency();
        }
    }
}
