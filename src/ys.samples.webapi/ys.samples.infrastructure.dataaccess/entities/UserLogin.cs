using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ys.samples.dataaccess;

namespace ys.samples.infrastructure.entities {
    [AppTable("userlogins")]
    public class UserLogin : IPersistentEntity {
        public long Id {
            get;set;
        }
        public string Password {
            get;set;
        }
        public long? userId {
            get;
            set;
        }
        public virtual User user {
            get;set;
        }
    }
}
