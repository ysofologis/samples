using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ys.samples.services {
    public interface IAuthenticationService {
        void AuthenticateRequest( IDomainServiceRequestContext reqctx );
        void Login( IDomainServiceRequestContext reqctx );
        void Logout( IDomainServiceRequestContext reqctx );
    }
}
