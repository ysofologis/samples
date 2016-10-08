using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ys.samples.dataaccess;

namespace ys.samples.devunion.entities {
    public interface IMemberEntity : IPersistentEntity {
        string Nickname {
            get;
            set;
        }
        string UserId {
            get;
            set;
        }
        string JobTitle {
            get;
            set;
        }
    }
    [DomainTable("members")]
    internal class Member : PersistentEntity, IMemberEntity {
        [Column("nickname")]
        [StringLength(50)]
        public string Nickname {
            get;
            set;
        }
        [Column("user_id")]
        [ReferenceKey]
        public string UserId {
            get;
            set;
        }
        [Column("job_title")]
        [StringLength(50)]
        public string JobTitle {
            get;set;
        }
    }
}
