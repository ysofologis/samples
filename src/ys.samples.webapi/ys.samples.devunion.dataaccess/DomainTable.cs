using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ys.samples.devunion {
    internal class DomainTable : TableAttribute {
        public const string DOMAIN_PREFIX = "devunion_";
        public DomainTable(string tableName): base( DOMAIN_PREFIX + tableName) {

        }
    }
}
