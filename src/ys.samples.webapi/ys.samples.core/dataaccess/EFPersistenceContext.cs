﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ys.samples.dataaccess {
    public class EFPersistenceContext : IPersistenceContext {
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
        private DbContext _EFContext;
        public EFPersistenceContext( DbContext efctx ) {
            _EFContext = efctx;
        }
        public void Dispose( ) {
            _EFContext.Dispose();
        }

        public IUnitOfWork StartWork( ) {
            return new UnitOfWork() {
                transaction = _EFContext.Database.BeginTransaction(),
            };
        }
    }
}
