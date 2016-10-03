using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ys.samples.dataaccess;

namespace ys.samples.infrastructure.entities {
    [AppTable("groups")]
    public class Group : PersistentEntity {
        [Index(IsUnique=true)]
        public string Name {
            get;
            set;
        }
    }
}
