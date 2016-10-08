using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ys.samples.dataaccess;

namespace ys.samples.devunion.entities {
    public interface ICompanyEntity : IPersistentEntity {
        string Name {
            get;
            set;
        }
        string Sobriquet {
            get;
            set;
        }
        string Address {
            get;
            set;
        }
        string UpdatedByMemberId {
            get;
            set;
        }
    }
    [DomainTable("companies")]
    internal class Company : PersistentEntity, ICompanyEntity {
        [Column("name")]
        [StringLength(50)]
        public string Name {
            get;
            set;
        }
        [Column("sobriquet")]
        [StringLength(50)]
        public string Sobriquet {
            get;
            set;
        }
        [Column("address")]
        [StringLength(50)]
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
