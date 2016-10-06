using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ys.samples.services {
    public class ObjectNotFoundException : Exception {
        public ObjectNotFoundException( string msg) : base(msg) {
        }
    }
}
