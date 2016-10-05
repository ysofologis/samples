using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ys.samples.services;

namespace ys.samples.infrastructure.groups {
    internal class GroupService : EFDomainService<GroupModel, entities.Group, GroupModelAdapter>, IGroupService {
        public GroupService( GroupRepository repo) : base(repo) {

        }
    }
}
