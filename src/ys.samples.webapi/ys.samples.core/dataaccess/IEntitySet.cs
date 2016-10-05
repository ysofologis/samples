using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ys.samples.dataaccess {
    public interface IEntitySet<EntityT> : IQueryable<EntityT>
        where EntityT: class, IPersistentEntity {
        EntityT Add( EntityT entity );
        EntityT Attach( EntityT entity );
        EntityT Create( );
        EntityT Find( params object[] keyValues );
        EntityT Remove( EntityT entity );
    }
}
