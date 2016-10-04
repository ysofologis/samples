using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ys.samples.dataaccess;

namespace ys.samples.infrastructure.entities {
    [AppTable("usergroups")]
    public class GroupMembership : PersistentEntity {
        [Column("user_id")]
        [ForeignKey("user")]
        public string userId {
            get;
            set;
        }
        public virtual User user {
            get;
            set;
        }
        [Column("group_id")]
        public string groupId {
            get;
            set;
        }
        public virtual Group group {
            get;
            set;
        }
    }
}
