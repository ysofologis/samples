using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ys.samples.shared {
    public interface IMockSetup : IDisposable {
        ServiceT Resolve<ServiceT>( );
    }
}
