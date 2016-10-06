using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ys.samples.dataaccess {
    public abstract class EFDataContext : DbContext {
        public EFDataContext( string connectionName ) : base(connectionName) {
        }
        public Type GetImplementationType( Type publicType ) {
            var objectContext = ( (IObjectContextAdapter) this).ObjectContext;
            var mdw = objectContext.MetadataWorkspace;
            var edmItems = mdw.GetItems<EntityType>(DataSpace.CSpace);
            var contextAssembly = this.GetType().Assembly;
            var internalTypes = contextAssembly.GetTypes();
            var entityType = internalTypes.Where(x => x.GetInterfaces().Contains(publicType)).FirstOrDefault();
            return entityType;
        }
    }
}
