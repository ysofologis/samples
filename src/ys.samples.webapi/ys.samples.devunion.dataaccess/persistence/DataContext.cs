using NHibernate;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Linq.Expressions;
using ys.samples.dataaccess;
using ys.samples.devunion.entities;

namespace ys.samples.devunion.persistence {
    public interface DevunionPersistenceContext : IPersistenceContext {
    }
    internal class DataContext : DevunionPersistenceContext {
        private class UnitOfWork : IUnitOfWork {
            public ISession nhibSession {
                get; private set;
            }
            public ITransaction workTransaction {
                get;
                private set;
            }
            public bool isSaved {
                get;
                private set;
            }
            public bool isDisposed {
                get;
                private set;
            }
            public UnitOfWork( ISession nhibSession ) {
                this.nhibSession = nhibSession;
                this.workTransaction = nhibSession.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
            }

            public void Save( ) {
                if ( !this.isDisposed ) {
                    this.nhibSession.Flush();
                    this.workTransaction.Commit();
                    this.isSaved = true;
                    this.workTransaction.Dispose();
                    this.isDisposed = true;
                }
            }

            public void Undo( ) {
                if ( !this.isDisposed ) {
                    this.workTransaction.Rollback();
                    this.workTransaction.Dispose();
                    this.isDisposed = true;
                }
            }

            public void Dispose( ) {
                if ( !this.isDisposed ) {
                    this.workTransaction.Rollback();
                    this.workTransaction.Dispose();
                    this.isDisposed = true;
                }
            }
        }
        private class EntitySet<EntityT> : dataaccess.IEntitySet<EntityT>
            where EntityT : class, dataaccess.IPersistentEntity {
            public ISession nhibSession {
                get;
                set;
            }
            public Type ElementType {
                get {
                    return typeof(EntityT);
                }
            }

            public Expression Expression {
                get {
                    return this.nhibSession.Query<EntityT>().Expression;
                }
            }

            public IQueryProvider Provider {
                get {
                    return this.nhibSession.Query<EntityT>().Provider;
                }
            }

            public EntityT Add( EntityT entity ) {
                this.nhibSession.SaveOrUpdate(entity);
                return entity;
            }

            public IEnumerable<EntityT> AddRange( IEnumerable<EntityT> entities ) {
                List<EntityT> result = new List<EntityT>();
                foreach( var e in entities ) {
                    result.Add(this.Add(e));
                }
                return result;
            }

            public EntityT Attach( EntityT entity ) {
                this.nhibSession.Lock(entity, LockMode.None);
                return entity;
            }

            public EntityT Create( ) {
                var actualType = EntityMapper.GetImplementorType(typeof(EntityT));
                return (EntityT) Activator.CreateInstance(actualType);
            }

            public EntityT Find( params object[] keyValues ) {
                 return (EntityT) this.nhibSession.Get(typeof(EntityT), keyValues[0]);
            }

            public IEnumerator<EntityT> GetEnumerator( ) {
                return this.nhibSession.Query<EntityT>().GetEnumerator();
            }

            public EntityT Remove( EntityT entity ) {
                this.nhibSession.Delete(entity);
                return entity;
            }

            public void SetModified( EntityT entity ) {
                this.nhibSession.Merge(entity);
            }

            IEnumerator IEnumerable.GetEnumerator( ) {
                return this.nhibSession.Query<EntityT>().GetEnumerator();
            }
        }
        ISession _session;
        string _SQLschema;
        public DataContext( PersistenceSetup setup) {
            _session = setup.sessionFactory.OpenSession();
            _SQLschema = setup.SQLSchema;
        }
        public void Dispose( ) {
            _session.Dispose();
        }

        public object GetUnderlyingSession( ) {
            return _session;
        }

        public IUnitOfWork StartWork( bool joinExistingWork ) {
            return new UnitOfWork(_session);
        }

        IEntitySet<EntityT> dataaccess.IPersistenceContext.GetEntitySet<EntityT>( ) {
            return new EntitySet<EntityT>() {
                nhibSession = _session,
            };
        }

        public string generateSQLSchema( ) {
            return _SQLschema;
        }

        public void Save( ) {
            _session.Flush();
        }
    }
}
