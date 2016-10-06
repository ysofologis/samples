using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ys.samples.dataaccess;

namespace ys.samples.devunion.entities {
    [DomainTable("team_periods")]
    public class TeamPeriod : PersistentEntity {
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
        public string ManagerSobriquet {
            get;set;
        }
    }
}
