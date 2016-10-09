using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ys.samples.dataaccess;

namespace ys.samples.devunion.entities {
    public interface ICompanyEntity : ITrackedEntity {
        string name {
            get;
            set;
        }
        string sobriquet {
            get;
            set;
        }
        string address {
            get;
            set;
        }
        IList<ICompanyTeamEntity> teams {
            get;
        }
    }
    internal class Company : TrackedPersistentEntity, ICompanyEntity {
        public virtual string name {
            get;
            set;
        }
        public virtual string sobriquet {
            get;
            set;
        }
        public virtual string address {
            get;
            set;
        }
        public virtual IList<CompanyTeam> teams {
            get;
            set;
        }
        IList<ICompanyTeamEntity> ICompanyEntity.teams {
            get {
                return ( IList<ICompanyTeamEntity> ) this.teams;
            }
        }
    }
    internal class CompanyMap : EntityMap<Company> {
        public CompanyMap( ) {
            Table("devunion_companies");
            Map(x => x.address, "company_address").Nullable();
            Map(x => x.name, "company_name");
            Map(x => x.sobriquet, "company_sobriquet");
            HasMany<CompanyTeam>(x => x.teams).KeyColumn("company_id").Inverse().Cascade.All();
            
        }
    }
}
