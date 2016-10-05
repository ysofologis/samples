using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ys.samples.services {
    public class SessionExpiredException : Exception {
        public SessionExpiredException( string sessionId ) : base("Session [" + sessionId + "] expired") {
        }
    }
}
