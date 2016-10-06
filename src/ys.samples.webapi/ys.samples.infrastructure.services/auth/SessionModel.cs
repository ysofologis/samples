using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ys.samples.services;

namespace ys.samples.infrastructure.auth {
    public class SessionModel : IDomainModel {
        public string Id {
            get;set;
        }
        public string userId {
            get;set;
        }
        public DateTime loginDate {
            get;set;
        }
        public DateTime logoutDate {
            get;set;
        }
        public int loginFailures {
            get;
            set;
        }
    }
}
