using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ys.samples.dataaccess;

namespace ys.samples.devunion.entities {
    public interface ITeamCommentEntity : IPersistentEntity {
        string TeamId {
            get;
            set;
        }
        string PostedByMemberId {
            get;
            set;
        }
        string Comment {
            get;
            set;
        }
        string PeriodId {
            get;
            set;
        }
    }
    [DomainTable("team_comments")]
    internal class TeamComment : PersistentEntity, ITeamCommentEntity {
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
