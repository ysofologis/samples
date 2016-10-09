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
using ys.samples.dataaccess;
using ys.samples.infrastructure.persistance;

namespace ys.samples.infrastructure {
    public class Module : Autofac.Module {
        private IPersistenceContext resolvePersistence( IComponentContext ctx ) {
            return ctx.Resolve<InfraPersistenceContext>();
        }
        protected override void Load( ContainerBuilder builder ) {
            base.Load(builder);

            builder.Register<SessionRepository>( x => new SessionRepository(resolvePersistence(x)) ).InstancePerDependency();
            builder.RegisterType<auth.AuthService>().As<services.IAuthenticationService>().InstancePerDependency().PropertiesAutowired();

            builder.Register<UserRepository>(x => new UserRepository(resolvePersistence(x))).InstancePerDependency();
            builder.Register<UserLoginRepository>(x => new UserLoginRepository(resolvePersistence(x))).InstancePerDependency();
            builder.RegisterType<UserService>().As<IUserService>().InstancePerDependency().PropertiesAutowired();

            builder.Register<GroupRepository>(x => new GroupRepository(resolvePersistence(x))).InstancePerDependency();
            builder.RegisterType<GroupService>().As<IGroupService>().InstancePerDependency().PropertiesAutowired();


            // this module initialization/setup class
            builder.RegisterType<ModuleSetup>().As<IModuleSetup>().SingleInstance();
        }
    }
}
