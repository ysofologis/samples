using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ys.samples.dataaccess {
    public class EFEntitySetWrapper<EntityT> : IEntitySet<EntityT>
        where EntityT : class, IPersistentEntity,new() {
        private DbSet<EntityT> _dbset;
        private DbContext _dbctx;
        public EFEntitySetWrapper(DbContext dbctx) {
            _dbset = _dbctx.Set<EntityT>();
            _dbctx = dbctx;
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
            return _dbset.Add(entity);
        }

        public EntityT Attach( EntityT entity ) {
            return _dbset.Attach(entity);
        }

        public EntityT Create( ) {
            return _dbset.Create();
        }

        public EntityT Find( params object[] keyValues ) {
            return _dbset.Find(keyValues);
        }

        public IEnumerator<EntityT> GetEnumerator( ) {
            return ( _dbset as IQueryable<EntityT>).GetEnumerator();
        }

        public EntityT Remove( EntityT entity ) {
            return _dbset.Remove(entity);
        }

        public void SetModified( EntityT entity ) {
            _dbctx.Entry(entity).State = EntityState.Modified;
        }

        IEnumerator IEnumerable.GetEnumerator( ) {
            return ( _dbset as IQueryable ).GetEnumerator();
        }

        public IEnumerable<EntityT> AddRange( IEnumerable<EntityT> entities ) {
            return _dbset.AddRange(entities);
        }
    }
}
