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
        where EntityT : class, IPersistentEntity {
        private DbSet<EntityT> _dbset;
        public EFEntitySetWrapper( DbSet<EntityT> dbset ) {
            _dbset = dbset;
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

        IEnumerator IEnumerable.GetEnumerator( ) {
            return ( _dbset as IQueryable ).GetEnumerator();
        }
    }
}
