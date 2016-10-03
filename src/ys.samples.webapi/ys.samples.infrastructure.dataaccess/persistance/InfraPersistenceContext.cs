using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ys.samples.dataaccess;

namespace ys.samples.infrastructure.persistance {
    internal class InfraPersistenceContext : EFPersistenceContext {
        public InfraPersistenceContext( InfraDBContext dbContext) : base(dbContext) {

        }
    }
}
