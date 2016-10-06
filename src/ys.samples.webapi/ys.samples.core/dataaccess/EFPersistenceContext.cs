using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ys.samples.dataaccess {
    public abstract class EFPersistenceContext : IPersistenceContext {
        private class UnitOfWork : IUnitOfWork {
            public DbContext context {
                get;
                set;
            }
            public DbContextTransaction transaction {
                get;
                set;
            }
            public bool handled {
                get; private set;
            }
            public bool disposed {
                get; private set;
            }
            public bool saved {
                get; private set;
            }
            public void Dispose( ) {
                if ( !this.handled ) {
                    this.transaction.Rollback();
                }
                this.transaction.Dispose();
                this.disposed = true;
            }

            public void Save( ) {
                this.context.SaveChanges();
                this.transaction.Commit();
                this.handled = true;
                this.saved = true;
            }

            public void Undo( ) {
                this.transaction.Rollback();
                this.handled = true;
            }
        }
        private EFDataContext _EFContext;
        private UnitOfWork _currentUoW;
        public EFPersistenceContext( EFDataContext efctx ) {
            _EFContext = efctx;
        }
        public void Dispose( ) {
            _EFContext.Dispose();
        }

        public IEntitySet<EntityT> GetEntitySet<EntityT>( ) where EntityT : class, IPersistentEntity {
            return new EFEntitySetWrapper<EntityT>( _EFContext );
        }
        public IUnitOfWork StartWork( bool joinExistingWork ) {
            if ( joinExistingWork ) {
                if ( _currentUoW == null || _currentUoW.disposed ) {
                    _currentUoW = new UnitOfWork() {
                        context = _EFContext,
                        transaction = _EFContext.Database.BeginTransaction(),
                    };
                }
                return _currentUoW;
            } else {
                var uow = new UnitOfWork() {
                    context = _EFContext,
                    transaction = _EFContext.Database.BeginTransaction(),
                };
                if ( _currentUoW == null || _currentUoW.disposed ) {
                    _currentUoW = uow;
                }
                return uow;
            }
        }

        public object GetUnderlyingSession( ) {
            return _EFContext;
        }
    }
}
