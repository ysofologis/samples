using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ys.samples.dataaccess;

namespace ys.samples.devunion.entities {
    public interface ICompanyTeamEntity: IPersistentEntity {
        string Name {
            get;
            set;
        }
        string Sobriquet {
            get;
            set;
        }
        string UpdatedByMemberId {
            get;
            set;
        }
    }
    [DomainTable("company_teams")]
    internal class CompanyTeam : PersistentEntity, ICompanyTeamEntity {
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
        [Column("member_id")]
        [ReferenceKey]
        public string UpdatedByMemberId {
            get; set;
        }
        public virtual Member UpdatedByMember {
            get;
            set;
        }
    }
}
