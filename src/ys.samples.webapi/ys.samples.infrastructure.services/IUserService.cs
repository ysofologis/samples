using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ys.samples.services;

namespace ys.samples.infrastructure {
    public interface IUserService : IDomainService<UserModel> {
    }
}
