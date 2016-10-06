using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ys.samples.services {
    public class ExpectationFailedException : Exception {
        public ExpectationFailedException(string msg) : base(msg) {

        }
    }
}
