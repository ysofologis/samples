using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using ys.samples.dataaccess;
using ys.samples.infrastructure;
using ys.samples.infrastructure.entities;
using ys.samples.services;

namespace ys.samples.shared {
    public abstract class AutofacTestCase<MockSetupT> : IClassFixture<MockSetupT>
        where MockSetupT: class, IMockSetup {
        public MockSetupT setup {
            get;
            private set;
        }
        public AutofacTestCase( MockSetupT setup ) {
            this.setup = setup;
        }
        protected IDomainServiceRequestContext setUserSession( ILifetimeScope currentScope, string username, string password ) {
            var perctx = currentScope.Resolve<IPersistenceContext>();
            var users = perctx.GetEntitySet<User>();
            var user = users.Where(x => x.Name == username).FirstOrDefault();
            if ( user == null ) {
                user = users.Add(new User() {
                    Name = username
                });
                user.makeUnique();
            }
            var userLogins = perctx.GetEntitySet<UserLogin>();
            var login = userLogins.Where(x => x.userId == user.Id).FirstOrDefault();
            if ( login == null ) {
                login = userLogins.Add(new UserLogin() {
                    userId = user.Id,
                    userPassword = password,
                });
                login.makeUnique();
            }
            var userSessions = perctx.GetEntitySet<UserSession>();
            var loginSession = userSessions.Where(x => x.userLoginId == login.Id).FirstOrDefault();
            if ( loginSession == null ) {
                loginSession = userSessions.Add(new UserSession() {
                    userLoginId = login.Id,
                    LoginDate = DateTime.Now,
                });
                loginSession.makeUnique();
            }
            var reqctx = new DomainServiceRequestContextForTests();
            reqctx.headers["session-id"] = loginSession.Id;
            return reqctx;
        }
    }
}
