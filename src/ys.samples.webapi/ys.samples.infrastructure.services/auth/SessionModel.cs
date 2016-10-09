using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ys.samples.services;

namespace ys.samples.infrastructure.auth {
    public class SessionModel : IDomainModel {
        public string id {
            get;set;
        }
        public string userLoginId {
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
