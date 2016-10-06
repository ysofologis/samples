using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ys.samples.dataaccess {
    public interface IEntitySet<EntityT> : IQueryable<EntityT>, IEntityFactory<EntityT>
        where EntityT: class, IPersistentEntity {
        EntityT Add( EntityT entity );
        IEnumerable<EntityT> AddRange( IEnumerable<EntityT> entities );
        EntityT Attach( EntityT entity );
        EntityT Find( params object[] keyValues );
        EntityT Remove( EntityT entity );
        void SetModified( EntityT entity );
    }
}
