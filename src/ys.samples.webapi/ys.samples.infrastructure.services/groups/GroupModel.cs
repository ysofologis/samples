using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ys.samples.services;

namespace ys.samples.infrastructure.groups {
    public class GroupModel : IDomainModel {
        public string Id {
            get;set;
        }

        public string Name {
            get;
            set;
        }
    }
}
