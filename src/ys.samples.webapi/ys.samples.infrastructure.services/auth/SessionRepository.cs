using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ys.samples.dataaccess;

namespace ys.samples.infrastructure.auth {
    internal class SessionRepository : EntityRepository<entities.IUserSessionEntity> {
        public SessionRepository( IPersistenceContext perctx ) : base(perctx) {
        }
    }
}
