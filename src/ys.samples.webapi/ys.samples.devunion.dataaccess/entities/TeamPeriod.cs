using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ys.samples.dataaccess;

namespace ys.samples.devunion.entities {
    public interface ITeamPeriodEntity : IPersistentEntity {
        string TeamId {
            get;
            set;
        }
        DateTime FromDate {
            get;
            set;
        }
        DateTime ToDate {
            get;
            set;
        }
        string Manager {
            get;
            set;
        }
    }
    [DomainTable("team_periods")]
    internal class TeamPeriod : PersistentEntity, ITeamPeriodEntity {
        [Column("team_id")]
        [ReferenceKey]
        public string TeamId {
            get;
            set;
        }
        public virtual CompanyTeam Team {
            get; set;
        }
        [Column("from_date")]
        public DateTime FromDate {
            get;
            set;
        }
        [Column("to_date")]
        public DateTime ToDate {
            get;
            set;
        }
        [Column("manager_sobriquet")]
        [Index(IsUnique =true)]
        [StringLength(50)]
        public string Manager {
            get;set;
        }
    }
}
