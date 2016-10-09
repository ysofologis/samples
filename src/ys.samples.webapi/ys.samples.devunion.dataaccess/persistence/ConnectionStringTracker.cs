using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ys.samples.devunion.persistence {
    public class ConnectionStringTracker {
        public virtual string getConnectionString( ) {
            return @"Data Source=|DataDirectory|ys.samples.devunion.sdf;";
        }
        public virtual bool shouldCreateSchema( ) {
            return false;
        }
    }
}
