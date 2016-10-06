using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ys.samples.shared {
    public abstract class UsingAutofacTest : IClassFixture<DependencyResolutionFixture> {
        public DependencyResolutionFixture fixture {
            get;
            private set;
        }
        public UsingAutofacTest( DependencyResolutionFixture fixture) {
            this.fixture = fixture;
        }
    }
}
