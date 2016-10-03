using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ys.samples.dataaccess;

namespace ys.samples.infrastructure.entities {
    [AppTable("users")]
    public class User : PersistentEntity {
        [Index("IX_NAME", IsUnique =true)]
        public string Name {
            get; set;
        }
        public string FirstName {
            get;set;
        }
        public string LastName {
            get; set;
        }
        public string Email {
            get; set;
        }
    }
}
