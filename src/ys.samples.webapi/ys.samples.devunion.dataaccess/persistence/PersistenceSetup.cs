using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ys.samples.devunion.persistence {
    internal class PersistenceSetup {
        private Configuration nhibConfig {
            get; set;
        }
        public bool hasBeenSet {
            get; private set;
        }
        public PersistenceSetup( ) {
            this.nhibConfig = new Configuration();
            this.hasBeenSet = false;
        }
        public ISessionFactory buildSessionFactory( ) {
            return this.nhibConfig.BuildSessionFactory();
        }
        public string exportSQLSchema( ) {
            var export = new SchemaExport(this.nhibConfig);
            using ( var writer = new StringWriter() ) {
                export.Execute(null, false, false, writer);
                var r = writer.GetStringBuilder().ToString();
                return r;
            }
        }
        public void runSetup( Action<Configuration> closuse ) {
            if ( !this.hasBeenSet ) {
                closuse(this.nhibConfig);
                this.nhibConfig.Configure();
                this.nhibConfig.AddAssembly(this.GetType().Assembly);
                this.hasBeenSet = true;
            }
        }
    }
}
