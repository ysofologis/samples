using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ys.samples.services;

namespace ys.samples.infrastructure.users {
    public class UserModel : IDomainModel {
        public string Id {
            get;set;
        }
        public string FirstName {
            get;set;
        }
        public string LastName {
            get; set;
        }
        public string Email {
            get;set;
        }
    }
}
