using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ys.samples.infrastructure.entities;
using ys.samples.services;

namespace ys.samples.infrastructure.users {
    internal class UserService : EFDomainService<UserModel,IUserEntity,UserModelAdapter>, IUserService {
        public UserService( UserRepository entityRepo ) : base(entityRepo) {
        }
    }
}
