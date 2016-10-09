using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ys.samples.dataaccess;

namespace ys.samples.devunion.entities {
    public interface ICompanyTeamEntity: ITrackedEntity {
        string companyId {
            get;
            set;
        }
        string name {
            get;
            set;
        }
        string sobriquet {
            get;
            set;
        }
    }
    internal class CompanyTeam : TrackedPersistentEntity, ICompanyTeamEntity {
        public virtual string companyId {
            get;
            set;
        }
        public virtual Company company {
            get;
            set;
        }
        public virtual string name {
            get;
            set;
        }
        public virtual string sobriquet {
            get;
            set;
        }
        public virtual IList<CompanyTeamAffair> teamAffairs {
            get;
            set;
        }
    }
    internal class CompanyTeamMap : EntityMap<CompanyTeam> {
        public CompanyTeamMap( ) {
            Map(x => x.companyId, "company_id");
            Map(x => x.name, "team_name");
            Map(x => x.sobriquet, "team_sobriquet");
            References<Company>(x => x.company).Column("company_id");
            HasMany<CompanyTeamAffair>(x => x.teamAffairs).KeyColumn("team_id").Inverse().Cascade.All();
        }
    }
}
