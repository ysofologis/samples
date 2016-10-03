using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ys.samples.services {
    public interface IDomainServiceRequestContext {
        Dictionary<string, string> GetHeaders( );
    }
}
