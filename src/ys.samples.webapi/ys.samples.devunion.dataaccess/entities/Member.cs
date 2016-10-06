using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ys.samples.dataaccess;

namespace ys.samples.devunion.entities {
    [DomainTable("members")]
    public class Member : PersistentEntity {
        [Column("nickname")]
        public string NickName {
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
        public string JobTitle {
            get;set;
        }
    }
}
