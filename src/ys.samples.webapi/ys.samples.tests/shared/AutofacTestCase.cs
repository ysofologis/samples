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
            var users = perctx.GetEntitySet<IUserEntity>();
            var user = users.Where(x => x.Name == username).FirstOrDefault();
            if ( user == null ) {
                user = users.Create();
                user.makeUnique();
                user.Name = username;
                users.Add(user);
            }
            var userLogins = perctx.GetEntitySet<IUserLoginEntity>();
            var login = userLogins.Where(x => x.userId == user.id).FirstOrDefault();
            if ( login == null ) {
                login = userLogins.Create();
                login.userId = user.id;
                login.userPassword = password;
                login.makeUnique();
                userLogins.Add(login);
            }
            var userSessions = perctx.GetEntitySet<IUserSessionEntity>();
            var loginSession = userSessions.Where(x => x.userLoginId == login.id).FirstOrDefault();
            if ( loginSession == null ) {
                loginSession = userSessions.Create();
                loginSession.userLoginId = login.id;
                loginSession.LoginDate = DateTime.Now;
                loginSession.makeUnique();
                userSessions.Add(loginSession);
            }
            var reqctx = new DomainServiceRequestContextForTests();
            reqctx.headers["session-id"] = loginSession.id;
            return reqctx;
        }
    }
}
