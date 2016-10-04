using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ys.samples.dataaccess {
    public interface IEntityRepository {
        IPersistentEntity Insert( IPersistentEntity entity );
        IEnumerable<IPersistentEntity> InsertMany( IEnumerable<IPersistentEntity> entity );
        IPersistentEntity GetById( string id );
        IQueryable<IPersistentEntity> GetAll( Paging paging );
        IQueryable<IPersistentEntity> GetByFilter( Filtering filter, Paging paging );
        void Update( IPersistentEntity entity );
        void Delete( IPersistentEntity entity );
    }
}
