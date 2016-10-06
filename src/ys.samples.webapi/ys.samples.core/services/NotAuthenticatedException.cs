using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ys.samples.services {
    public class NotAuthenticatedException : Exception {
        public NotAuthenticatedException(string msg = "") : base(msg) {

        }
    }
}
