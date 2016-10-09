using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ys.samples.dataaccess;

namespace ys.samples.devunion.entities {
    public interface IEmployeeHistoryEntity : ITrackedEntity {
        string teamId {
            get;set;
        }
        string employeeId {
            get;
            set;
        }
        string teamRoles {
            get;
            set;
        }
        DateTime employedFrom {
            get;
            set;
        }
        DateTime employedTo {
            get;
            set;
        }
    }
    internal class ProfessionalHistory : TrackedPersistentEntity, IEmployeeHistoryEntity {
        public virtual string teamId {
            get;
            set;
        }
        public virtual CompanyTeam team {
            get;set;
        }
        public virtual string employeeId {
            get;
            set;
        }
        public virtual Member employee {
            get;
            set;
        }
        public virtual string teamRoles {
            get;set;
        }
        public virtual DateTime employedFrom {
            get;
            set;
        }
        public virtual DateTime employedTo {
            get;
            set;
        }
    }
    internal class ProfessionalHistoryMap : EntityMap<ProfessionalHistory> {
        public ProfessionalHistoryMap( ) {
            Map(x => x.teamId, "team_id");
            References<CompanyTeam>(x => x.team).Column("team_id");
            Map(x => x.employeeId, "employee_id");
            References<Member>(x => x.employee).Column("employee_id");
            Map(x => x.teamRoles, "team_roles").Nullable();
            Map(x => x.employedFrom, "employed_from");
            Map(x => x.employedTo, "employed_to");
        }
    }
}
