using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ys.samples.dataaccess;

namespace ys.samples.infrastructure.persistance {
    public interface InfraPersistenceContext : IPersistenceContext {
    }
    internal sealed class InternalPersistenceContext : EFPersistenceContext, InfraPersistenceContext {
        internal InternalPersistenceContext( InfraDBContext dbContext) : base(dbContext) {

        }
        public override string generateSQLSchema( ) {
            throw new NotImplementedException();
        }
    }
}
