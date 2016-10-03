using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ys.samples.dataaccess {
    public interface IPersistentEntity {
        string Id {
            get;
        }
        void MakeUnique( );
    }
}
