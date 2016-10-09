using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ys.samples.dataaccess;

namespace ys.samples.devunion.entities {
    public interface ITeamAffairEntity : ITrackedEntity {
        string teamId {
            get;
            set;
        }
        string whatHappened {
            get;
            set;
        }
        DateTime occurredFrom {
            get;
            set;
        }
        DateTime occurredTo {
            get;
            set;
        }
    }
    internal class CompanyTeamAffair : TrackedPersistentEntity, ITeamAffairEntity {
        public virtual string teamId {
            get;
            set;
        }
        public virtual CompanyTeam team {
            get;
            set;
        }
        public virtual string whatHappened {
            get;
            set;
        }
        public virtual DateTime occurredFrom {
            get;set;
        }
        public virtual DateTime occurredTo {
            get; set;
        }
    }
    internal class CompanyTeamAffairMap : EntityMap<CompanyTeamAffair> {
        public CompanyTeamAffairMap( ) {
            Map(x => x.teamId, "team_id");
            Map(x => x.whatHappened, "what_happened");
            Map(x => x.occurredFrom, "occurred_from");
            Map(x => x.occurredTo, "occurred_to");
            References<CompanyTeam>(x => x.team).Column("team_id");
        }
    }
}
