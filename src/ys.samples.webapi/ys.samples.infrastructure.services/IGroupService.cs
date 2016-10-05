using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ys.samples.infrastructure.groups;
using ys.samples.services;

namespace ys.samples.infrastructure {
    public interface IGroupService : IDomainService<GroupModel> {
    }
}
