using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ys.samples.dataaccess;

namespace ys.samples.infrastructure.persistance {
    public sealed class InfraPersistenceContext : EFPersistenceContext {
        internal InfraPersistenceContext( InfraDBContext dbContext) : base(dbContext) {

        }
    }
}
