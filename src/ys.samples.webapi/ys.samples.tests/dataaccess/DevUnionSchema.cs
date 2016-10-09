using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using ys.samples.devunion.persistence;
using ys.samples.shared;

namespace ys.samples.dataaccess {
    [Trait("DataAccess","NHibernate")]
    public class DevUnionSchema : AutofacTestCase<LocalSQLCeMock> {
        public DevUnionSchema( LocalSQLCeMock fixture ) : base(fixture) {
        }
        [Fact(DisplayName ="Should Create DB Schema")]
        public void it_should_generate_schema( ) {
            using ( var scope = this.fixture.beginMethodScope() ) {
                var perctx = scope.Resolve<DevunionPersistenceContext>();
                var sqlSchema = perctx.generateSQLSchema();
                Assert.NotEmpty(sqlSchema);
            }
        }
    }
}
