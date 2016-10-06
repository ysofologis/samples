using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ys.samples.dataaccess {
    public interface IPersistenceContext : IDisposable {
        IUnitOfWork StartWork( bool joinExistingWork );
        object GetUnderlyingSession( );
        IEntitySet<EntityT> GetEntitySet<EntityT>( ) where EntityT : class, IPersistentEntity;
    }
}
