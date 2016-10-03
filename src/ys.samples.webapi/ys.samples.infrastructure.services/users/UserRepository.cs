using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ys.samples.dataaccess;
using ys.samples.infrastructure.entities;

namespace ys.samples.infrastructure.users {
    internal class UserRepository: EFEntityRepository<User> {
        public UserRepository(IPersistenceContext perctx) : base(perctx) {

        }
    }
}
