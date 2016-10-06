using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using ys.samples.infrastructure;
using ys.samples.infrastructure.groups;
using ys.samples.infrastructure.users;
using ys.samples.mocks;
using ys.samples.shared;

namespace ys.samples.services {
    [Trait("Services","Authentication")]
    public class AuthenticationTests : AutofacTestCase<MockPersistanceContextSetup> {
        public AuthenticationTests( MockPersistanceContextSetup setup ) : base(setup) {
        }

        [Fact(DisplayName ="Should Return No Groups")]
        public void it_should_return_no_groups( ) {
            using ( var scope = this.setup.beginMethodScope() ) {
                var reqctx = setUserSession(scope, "user01", "111111");
                var service = scope.Resolve<IGroupService>();
                var groups = service.GetAll(reqctx, new Paging());
                Assert.Equal(groups.Count(), 0);
            }
        }
        [Fact(DisplayName = "Should Return Default Groups")]
        public void it_should_return_default_groups( ) {
            using ( var scope = this.setup.beginMethodScope() ) {
                var reqctx = setUserSession(scope, "user01", "111111");
                var service = scope.Resolve<IGroupService>();
                var groupList = new List<GroupModel>();
                groupList.Add(new GroupModel() {
                    Name = "admins"
                });
                groupList.Add(new GroupModel() {
                    Name = "users"
                });
                groupList.Add(new GroupModel() {
                    Name = "operators"
                });
                service.AddBatch(reqctx, groupList);

                var groups = service.GetAll(reqctx, new Paging());
                Assert.Equal(groups.Count(), groupList.Count);
            }
        }
        [Fact(DisplayName = "Should Return The Session User")]
        public void it_should_return_no_users( ) {
            using ( var scope = this.setup.beginMethodScope() ) {
                var reqctx = setUserSession(scope, "user01", "111111");
                var service = scope.Resolve<IUserService>();
                var users = service.GetAll(reqctx, new Paging());
                Assert.Equal(users.Count(), 1);
            }
        }
        [Fact(DisplayName = "Should Return Default Users")]
        public void it_should_return_default_users( ) {
            using ( var scope = this.setup.beginMethodScope() ) {
                var reqctx = setUserSession(scope, "user01", "111111");
                var service = scope.Resolve<IUserService>();
                var groupList = new List<UserModel>();
                groupList.Add(new UserModel() {
                    Email = "admin@example.com"
                });
                groupList.Add(new UserModel() {
                    Email = "user@example.com"
                });
                groupList.Add(new UserModel() {
                    Email = "operator@example.com"
                });
                service.AddBatch(reqctx, groupList);

                var groups = service.GetAll(reqctx, new Paging());
                Assert.Equal(groups.Count(), groupList.Count + 1);
            }
        }

    }
}
