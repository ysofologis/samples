using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ys.samples.dataaccess;

namespace ys.samples.shared {
    class InMemoryPersistentContext : IPersistenceContext {
        private class UnitOfWork : IUnitOfWork {
            public void Dispose( ) {
            }

            public void Save( ) {
            }

            public void Undo( ) {
            }
        }
        private class EntitySetWrapper<EntityT> : IEntitySet<EntityT>
            where EntityT : class, IPersistentEntity, new() {
            public List<EntityT> Entities {
                get;
                set;
            }
            public Type ElementType {
                get {
                    return this.Entities.AsQueryable().ElementType;
                }
            }

            public Expression Expression {
                get {
                    return this.Entities.AsQueryable().Expression;
                }
            }

            public IQueryProvider Provider {
                get {
                    return this.Entities.AsQueryable().Provider;
                }
            }

            public EntityT Add( EntityT entity ) {
                entity.makeUnique();
                this.Entities.Add(entity);
                return entity;
            }

            public IEnumerable<EntityT> AddRange( IEnumerable<EntityT> entities ) {
                foreach ( var e in entities ) {
                    e.makeUnique();
                }
                this.Entities.AddRange(entities);
                return entities;
            }

            public EntityT Attach( EntityT entity ) {
                if ( this.Entities.IndexOf(entity) < 0 ) {
                    this.Entities.Add(entity);
                }
                return entity;
            }

            public EntityT Create( ) {
                return new EntityT();
            }

            public EntityT Find( params object[] keyValues ) {
                return this.Entities.Where(x => x.Id == keyValues[0].ToString()).FirstOrDefault();
            }

            public IEnumerator<EntityT> GetEnumerator( ) {
                return this.Entities.GetEnumerator();
            }

            public EntityT Remove( EntityT entity ) {
                this.Entities.Remove(entity);
                return entity;
            }

            public void SetModified( EntityT entity ) {
                
            }

            IEnumerator IEnumerable.GetEnumerator( ) {
                return this.Entities.GetEnumerator();
            }
        }
        private Dictionary<Type,IEnumerable<IPersistentEntity>> _entitySets;
        public InMemoryPersistentContext( ) {
            _entitySets = new Dictionary<Type, IEnumerable<IPersistentEntity>>();
        }
        public void Dispose( ) {
            _entitySets.Clear();
        }

        public object GetUnderlyingSession( ) {
            return _entitySets;
        }

        public IUnitOfWork StartWork( bool joinExistingWork ) {
            return new UnitOfWork() { };
        }

        IEntitySet<EntityT> IPersistenceContext.GetEntitySet<EntityT>( ) {
            if ( !_entitySets.ContainsKey(typeof(EntityT)) ) {
                _entitySets[typeof(EntityT)] = new List<EntityT>();
            }
            return new EntitySetWrapper<EntityT>() { Entities = (List<EntityT>) _entitySets[typeof(EntityT)] };
        }
    }
}
