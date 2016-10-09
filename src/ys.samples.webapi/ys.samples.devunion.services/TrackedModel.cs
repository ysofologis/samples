using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ys.samples.services;

namespace ys.samples.devunion {
    public abstract class TrackedModel : IDomainModel {
        public string id {
            get;
            set;
        }
        public DateTime? dateInserted {
            get;
            set;
        }
        public DateTime? dateUpdated {
            get;
            set;
        }
        public string updatedBy {
            get;
            set;
        }
    }
}
