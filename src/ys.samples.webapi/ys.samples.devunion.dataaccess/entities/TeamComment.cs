using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ys.samples.dataaccess;

namespace ys.samples.devunion.entities {
    [DomainTable("team_comments")]
    public class TeamComment : PersistentEntity {
        [Column("team_id")]
        [ReferenceKey]
        public string TeamId {
            get;
            set;
        }
        public virtual CompanyTeam Team {
            get;set;
        }
        [Column("posted_by")]
        [ReferenceKey]
        public string PostedByMemberId {
            get;
            set;
        }
        public virtual Member PostedByMember {
            get;
            set;
        }
        [Column("comment", TypeName = "text")]
        public string Comment {
            get;
            set;
        }
        [Column("period_id")]
        [ReferenceKey]
        public string PeriodId {
            get;
            set;
        }
    }
}
