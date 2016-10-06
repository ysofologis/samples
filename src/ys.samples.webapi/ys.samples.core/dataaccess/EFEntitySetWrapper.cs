using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ys.samples.dataaccess {
    public class EFEntitySetWrapper<EntityT> : IEntitySet<EntityT>
        where EntityT : class, IPersistentEntity {
        private DbSet _dbset;
        private EFDataContext _dbctx;
        public EFEntitySetWrapper(EFDataContext dbctx) {
            _dbctx = dbctx;
            _dbset = _dbctx.Set( dbctx.GetImplementationType(typeof(EntityT)));
        }
        public Type ElementType {
            get {
                return (_dbset as IQueryable).ElementType;
            }
        }

        public Expression Expression {
            get {
                return ( _dbset as IQueryable ).Expression;
            }
        }

        public IQueryProvider Provider {
            get {
                return ( _dbset as IQueryable ).Provider;
            }
        }

        public EntityT Add( EntityT entity ) {
            return (EntityT) _dbset.Add(entity);
        }

        public EntityT Attach( EntityT entity ) {
            return (EntityT) _dbset.Attach(entity);
        }

        public EntityT Create( ) {
            return (EntityT) _dbset.Create();
        }

        public EntityT Find( params object[] keyValues ) {
            return (EntityT) _dbset.Find(keyValues);
        }

        public IEnumerator<EntityT> GetEnumerator( ) {
            return ( _dbset as IQueryable<EntityT>).GetEnumerator();
        }

        public EntityT Remove( EntityT entity ) {
            return (EntityT) _dbset.Remove(entity);
        }

        public void SetModified( EntityT entity ) {
            _dbctx.Entry(entity).State = EntityState.Modified;
        }

        IEnumerator IEnumerable.GetEnumerator( ) {
            return ( _dbset as IQueryable ).GetEnumerator();
        }

        public IEnumerable<EntityT> AddRange( IEnumerable<EntityT> entities ) {
            return (IEnumerable<EntityT>) _dbset.AddRange(entities);
        }
    }
}
