using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ys.samples.infrastructure.entities;
using ys.samples.services;

namespace ys.samples.infrastructure.groups {
    internal class GroupService : DomainServiceSkeleton<GroupModel, IGroupEntity, GroupModelAdapter>, IGroupService {
        public GroupService( GroupRepository repo) : base(repo) {

        }
    }
}
