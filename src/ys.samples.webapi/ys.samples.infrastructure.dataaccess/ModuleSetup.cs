using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using ys.samples.ioc;
using ys.samples.infrastructure.persistance;

namespace ys.samples.infrastructure {
    internal class ModuleSetup : IModuleSetup {
        private const string GROUP_USERS = "users";
        private const string GROUP_ADMINS = "admins";
        private const string USER_ADMIN = "admin";
        private const string USER_ADMIN_PWD = "admin";

        public void setupModule( IContainer iocResolver ) {
            using ( var perctx = iocResolver.Resolve<InfraPersistenceContext>() ) {
                var dbctx = perctx.GetUnderlyingSession() as InfraDBContext;
                addDefaultGroups(dbctx);
                addDefaultUsers(dbctx);
            }
        }
        private void addDefaultGroups( InfraDBContext dbctx ) {
            var hasChanges = false;
            if ( ! dbctx.Groups.Any(x => x.Name == GROUP_USERS) ) {
                var group = new entities.Group() {
                    Name = GROUP_USERS,
                };
                group.MakeUnique();
                dbctx.Groups.Add(group);
                hasChanges = true;
            }
            if ( !dbctx.Groups.Any(x => x.Name == GROUP_ADMINS) ) {
                var group = new entities.Group() {
                    Name = GROUP_ADMINS,
                };
                group.MakeUnique();
                dbctx.Groups.Add(group);
                hasChanges = true;
            }
            if ( hasChanges ) {
                dbctx.SaveChanges();
            }
        }
        private void addDefaultUsers( InfraDBContext dbctx ) {
            if ( !dbctx.Users.Any(x => x.Name == USER_ADMIN) ) {
                var adminUser = new entities.User() {
                    Name = USER_ADMIN,
                    FirstName = "System",
                    LastName = "Administrator",
                    Email = "admin@example.com"
                };
                adminUser.MakeUnique();
                dbctx.Users.Add(adminUser);
                var login = new entities.UserLogin() {
                    user = adminUser,
                    Password = USER_ADMIN_PWD,
                };
                login.MakeUnique();
                dbctx.UserLogins.Add(login);

                var adminGroup = dbctx.Groups.Where(x => x.Name == GROUP_ADMINS).Single();
                var membership = new entities.GroupMembership() {
                    user = adminUser,
                    group = adminGroup,
                };
                membership.MakeUnique();
                dbctx.UserGroups.Add(membership);

                dbctx.SaveChanges();
            }
        }
    }
}
