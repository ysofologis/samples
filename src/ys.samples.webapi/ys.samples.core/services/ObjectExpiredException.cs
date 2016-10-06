using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ys.samples.services {
    public class ObjectExpiredException : Exception {
        public ObjectExpiredException( string sessionId ) : base("Session [" + sessionId + "] expired") {
        }
    }
}
