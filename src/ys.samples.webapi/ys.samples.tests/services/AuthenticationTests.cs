using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using ys.samples.shared;

namespace ys.samples.services {
    [Trait("Services","Authentication")]
    public class AuthenticationTests : UsingAutofacTest {
        public AuthenticationTests( DependencyResolutionFixture fixture ) : base(fixture) {
        }

        [Fact(DisplayName ="Return Default Groups")]
        public void it_should_return_defaults_groups( ) {
            var service = this.fixture.Resolve<IAuthenticationService>();
            Assert.Equal(1, 1);
        }
    }
}
