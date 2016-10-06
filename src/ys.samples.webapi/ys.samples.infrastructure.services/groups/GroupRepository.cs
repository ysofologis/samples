using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ys.samples.dataaccess;

namespace ys.samples.infrastructure.groups {
    internal class GroupRepository : EntityRepository<entities.Group> {
        public GroupRepository( IPersistenceContext ctx ) : base(ctx) {

        }
    }
}
