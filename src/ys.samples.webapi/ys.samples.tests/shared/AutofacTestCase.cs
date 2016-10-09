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
using ys.samples.infrastructure.persistance;
using ys.samples.services;

namespace ys.samples.shared {
    public abstract class AutofacTestCase<MockSetupT> : IClassFixture<MockSetupT>, IDisposable
        where MockSetupT: class, IMockSetup {
        public MockSetupT fixture {
            get;
            private set;
        }
        public AutofacTestCase( MockSetupT fixture ) {
            this.fixture = fixture;
            setup();
        }
        protected virtual void setup( ) {
        }
        protected virtual void tearDown( ) {
        }
        protected IDomainServiceRequestContext setUserSession( ILifetimeScope currentScope, string username, string password ) {
            var perctx = currentScope.Resolve<InfraPersistenceContext>();
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

        public void Dispose( ) {
            this.tearDown();
        }
    }
}
