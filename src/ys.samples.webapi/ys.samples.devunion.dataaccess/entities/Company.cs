using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ys.samples.dataaccess;

namespace ys.samples.devunion.entities {
    [DomainTable("companies")]
    public class Company : PersistentEntity {
        [Column("name")]
        public string Name {
            get;
            set;
        }
        [Column("sobriquet")]
        public string Sobriquet {
            get;
            set;
        }
        [Column("address")]
        public string Address {
            get;
            set;
        }
        [Column("update_by")]
        [ReferenceKey]
        public string UpdatedByMemberId {
            get;set;
        }
        public virtual Member UpdatedByMember {
            get; set;
        }
    }
}
