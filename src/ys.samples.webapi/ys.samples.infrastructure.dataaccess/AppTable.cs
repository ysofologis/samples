using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ys.samples.devunion {
    internal class AppTable : TableAttribute {
        public const string DOMAIN_PREFIX = "webapp_";
        public AppTable(string tableName): base( DOMAIN_PREFIX + tableName) {

        }
    }
}
