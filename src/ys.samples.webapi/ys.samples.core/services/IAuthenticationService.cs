using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ys.samples.services {
    public interface IAuthenticationService {
        void authenticateRequest( IDomainServiceRequestContext reqctx );
        string startSession( IDomainServiceRequestContext reqctx );
        void endSession( IDomainServiceRequestContext reqctx );
    }
}
