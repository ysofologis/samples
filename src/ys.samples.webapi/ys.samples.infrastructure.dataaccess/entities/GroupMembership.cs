using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ys.samples.dataaccess;

namespace ys.samples.infrastructure.entities {
    [AppTable("usergroups")]
    public class GroupMembership : IPersistentEntity {
        public long Id {
            get;set;
        }
        public long? userId;
        public virtual User user {
            get;
            set;
        }
        public long? groupId {
            get;
            set;
        }
        public virtual Group group {
            get;
            set;
        }
    }
}
