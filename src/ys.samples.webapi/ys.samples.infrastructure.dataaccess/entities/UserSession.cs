using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ys.samples.dataaccess;

namespace ys.samples.infrastructure.entities {
    [AppTable("usersessions")]
    public class UserSession : PersistentEntity {
        public DateTime LoginDate {
            get;
            set;
        }
        public DateTime LogoutDate {
            get;
            set;
        }
        public int LoginFailures {
            get;
            set;
        }
        public long? userLoginId {
            get;
            set;
        }
        public virtual UserLogin userLogin {
            get;
            set;
        }
    }
}
