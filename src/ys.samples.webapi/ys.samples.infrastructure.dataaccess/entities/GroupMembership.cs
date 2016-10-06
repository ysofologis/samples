using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ys.samples.dataaccess;

namespace ys.samples.infrastructure.entities {
    public interface IGroupMembershipEntity : IPersistentEntity {
        string userId {
            get;set;
        }
        string groupId {
            get; set;
        }
    }
    [AppTable("usergroups")]
    internal class GroupMembership : PersistentEntity, IGroupMembershipEntity {
        [Column("user_id")]
        [ForeignKey("user")]
        [StringLength(KEY_SIZE)]
        public string userId {
            get;
            set;
        }
        public virtual User user {
            get;
            set;
        }
        [Column("group_id")]
        [StringLength(KEY_SIZE)]
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
