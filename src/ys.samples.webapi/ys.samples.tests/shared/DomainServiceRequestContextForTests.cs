using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using ys.samples.services;

namespace ys.samples.shared {
    class DomainServiceRequestContextForTests : IDomainServiceRequestContext {
        public Dictionary<string, string> headers {
            get;
            private set;
        }
        public DomainServiceRequestContextForTests( ) {
            this.headers = new Dictionary<string, string>();
        }
        public IPrincipal User {
            get;set;
        }

        public Dictionary<string, string> GetHeaders( ) {
            return this.headers;
        }
    }
}
