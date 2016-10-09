using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ys.samples.devunion.persistence {
    internal class PersistenceSetup: IDisposable {
        public ISessionFactory sessionFactory {
            get;
            private set;
        }
        public string SQLSchema {
            get;
            private set;
        }
        public PersistenceSetup( ConnectionStringTracker connectionStringTracker ) {
            Trace.WriteLine("initializing session factory");
            this.sessionFactory = Fluently.Configure()
                .Database(MsSqlCeConfiguration.Standard.ConnectionString(connectionStringTracker.getConnectionString()))
                .Mappings(x => x.FluentMappings.AddFromAssemblyOf<DataContext>())
                .ExposeConfiguration(c => {
                    var export = new SchemaExport(c);
                    using ( var writer = new StringWriter() ) {
                        export.Execute(null, connectionStringTracker.shouldCreateSchema(), false, writer);
                        this.SQLSchema = writer.GetStringBuilder().ToString();
                    }
                }).BuildSessionFactory();
        }
        public void Dispose( ) {
            this.sessionFactory.Dispose();
        }
    }
}
