using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ys.samples.infrastructure.auth;
using ys.samples.infrastructure.users;
using ys.samples.services;

namespace ys.samples.infrastructure {
    public interface IUserService : IDomainService<UserModel> {
        SessionModel getSession( IDomainServiceRequestContext reqctx, string userId );
    }
}
