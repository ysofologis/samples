using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using ys.samples.ioc;
using ys.samples.infrastructure.persistance;
using ys.samples.dataaccess;
using System.Data.Entity;
using ys.samples.infrastructure.entities;

namespace ys.samples.infrastructure {
    internal class ModuleSetup : IModuleSetup {
        private const string GROUP_USERS = "users";
        private const string GROUP_ADMINS = "admins";
        private const string USER_ADMIN = "admin";
        private const string USER_ADMIN_PWD = "admin";

        public void setupModule( IContainer iocResolver ) {

            using ( var perctx = iocResolver.Resolve<IPersistenceContext>() ) {
                var test = perctx.GetEntitySet<IUserEntity>();
                var dbctx = perctx.GetUnderlyingSession() as InfraDBContext;
                if ( dbctx.isSQLite ) {
                    prepareSchemaForSQLite(dbctx);
                }
                addDefaultGroups(dbctx);
                addAdminUsers(dbctx);
                addDemoUser(dbctx, "demo01", "111111", "Demo 01", "Demo 01", "demo01@example.com");
                addDemoUser(dbctx, "demo02", "111111", "Demo 02", "Demo 02", "demo02@example.com");
            }
        }

        private void prepareSchemaForSQLite( InfraDBContext dbctx ) {
            Func<Exception,Exception> findException = ( e ) => {
                var finalEx = e;
                while ( finalEx.InnerException != null ) {
                    finalEx = finalEx.InnerException;
                }
                return finalEx;
            };
            try {
                dbctx.Users.Count();
            }catch(Exception e) {
                var x = findException(e);
                if ( x.Source.Equals("System.Data.SQLite", StringComparison.CurrentCultureIgnoreCase) ) {
                    dbctx.createSchemaForSqlite();
                }
            }
        }
        private void addDefaultGroups( InfraDBContext dbctx ) {
            var hasChanges = false;
            if ( ! dbctx.Groups.Any(x => x.Name == GROUP_USERS) ) {
                var group = new entities.Group() {
                    Name = GROUP_USERS,
                    dateInserted = DateTime.Now,
                    dateUpdated = DateTime.Now,
                };
                dbctx.Groups.Add(group.makeUnique());
                hasChanges = true;
            }
            if ( !dbctx.Groups.Any(x => x.Name == GROUP_ADMINS) ) {
                var group = new entities.Group() {
                    Name = GROUP_ADMINS,
                    dateInserted = DateTime.Now,
                    dateUpdated = DateTime.Now,
                };
                dbctx.Groups.Add(group.makeUnique());
                hasChanges = true;
            }
            if ( hasChanges ) {
                dbctx.SaveChanges();
            }
        }
        private void addAdminUsers( InfraDBContext dbctx ) {
            if ( !dbctx.Users.Any(x => x.Name == USER_ADMIN) ) {
                var adminUser = new entities.User() {
                    Name = USER_ADMIN,
                    FirstName = "System",
                    LastName = "Administrator",
                    Email = "admin@example.com",
                    dateInserted = DateTime.Now,
                    dateUpdated = DateTime.Now,
                };
                dbctx.Users.Add(adminUser.makeUnique());
                var login = new entities.UserLogin() {
                    user = adminUser,
                    userPassword = USER_ADMIN_PWD,
                    dateInserted = DateTime.Now,
                    dateUpdated = DateTime.Now,
                };
                dbctx.UserLogins.Add(login.makeUnique());

                var adminGroup = dbctx.Groups.Where(x => x.Name == GROUP_ADMINS).Single();
                var membership = new entities.GroupMembership() {
                    user = adminUser,
                    group = adminGroup,
                    dateInserted = DateTime.Now,
                    dateUpdated = DateTime.Now,
                };
                dbctx.UserGroups.Add(membership.makeUnique());

                dbctx.SaveChanges();
            }
        }
        private void addDemoUser( InfraDBContext dbctx, string userName, string userPwd, 
                                                    string firstName, string lastName, string email ) {
            var allUsers = dbctx.Set<User>();
            var demoUser = allUsers.Where(x => x.Name == userName).FirstOrDefault();
            if ( demoUser == null ) {
                demoUser = new User() {
                    Name = userName,
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    dateInserted = DateTime.Now,
                    dateUpdated = DateTime.Now,
                };
                demoUser.makeUnique();
                allUsers.Add(demoUser);

                var userLogin = new UserLogin() {
                    userId = demoUser.id,
                    userPassword = userPwd,
                    dateInserted = DateTime.Now,
                    dateUpdated = DateTime.Now,
                }.makeUnique();
                dbctx.Set<UserLogin>().Add(userLogin);

                var userSession = new UserSession() {
                    id = "session-for-" + userName,
                    LoginDate = DateTime.Now,
                    LogoutDate = DateTime.MinValue,
                    LoginFailures = 0,
                    userLoginId = userLogin.id,
                    dateInserted = DateTime.Now,
                    dateUpdated = DateTime.Now,
                };
                dbctx.Set<UserSession>().Add(userSession);

                dbctx.SaveChanges();
            } else {
                var userLogin = dbctx.Set<UserLogin>().Where(x => x.userId == demoUser.id).FirstOrDefault();
                var userSession = dbctx.Set<UserSession>().Where(x => x.userLoginId == userLogin.id).FirstOrDefault();
                userSession.LoginDate = DateTime.Now;
                dbctx.SaveChanges();
            }
        }
    }
}
