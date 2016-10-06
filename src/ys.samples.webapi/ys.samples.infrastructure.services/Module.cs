using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using ys.samples.infrastructure.users;
using ys.samples.ioc;
using ys.samples.infrastructure.groups;
using ys.samples.infrastructure.auth;

namespace ys.samples.infrastructure {
    public class Module : Autofac.Module {
        protected override void Load( ContainerBuilder builder ) {
            base.Load(builder);

            builder.RegisterType<SessionRepository>().InstancePerDependency();
            builder.RegisterType<auth.AuthService>().As<services.IAuthenticationService>().InstancePerDependency();

            builder.RegisterType<UserRepository>().InstancePerDependency();
            builder.RegisterType<UserLoginRepository>().InstancePerDependency();
            builder.RegisterType<UserService>().As<IUserService>().InstancePerDependency();

            builder.RegisterType<GroupRepository>().InstancePerDependency();
            builder.RegisterType<GroupService>().As<IGroupService>().InstancePerDependency();


            // this module initialization/setup class
            builder.RegisterType<ModuleSetup>().As<IModuleSetup>().SingleInstance();
        }
    }
}
