using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using ys.samples.devunion.entities;
using ys.samples.devunion.persistence;
using ys.samples.shared;

namespace ys.samples.dataaccess {
    [Trait("DataAccess", "NHibernate")]
    public class DevUnionCRUD : AutofacTestCase<LocalSQLCeMock> {
        public DevUnionCRUD( LocalSQLCeMock fixture ) : base(fixture) {
        }
        protected override void setup( ) {
            base.setup();
            using ( var perctx = this.fixture.Resolve<DevunionPersistenceContext>() ) {
                var companySet = perctx.GetEntitySet<ICompanyEntity>();
                addCompanyIfNotExists(companySet, "unixfor", "linuxfor");
                addCompanyIfNotExists(companySet, "codix", "sodix");
                addCompanyIfNotExists(companySet, "relational", "irrelational");
                perctx.Save();
            }
        }
        private void addCompanyIfNotExists( IEntitySet<ICompanyEntity> companySet, string companyName, string companySobriquet ) {
            if ( ! companySet.Any(x => x.name == companyName) ) {
                var entity = companySet.Create();
                entity.name = companyName;
                entity.sobriquet = companySobriquet;
                entity.address = "no address";
                entity.dateInserted = DateTime.Now;
                entity.dateUpdated = DateTime.Now;
                companySet.Add(entity);
            }
        }
        [Fact(DisplayName ="Should Get Default Companies")]
        public void it_should_get_default_companies( ) {
            using ( var scope = this.fixture.beginMethodScope() ) {
                using ( var perctx = scope.Resolve<DevunionPersistenceContext>() ) {
                    var companies = perctx.GetEntitySet<ICompanyEntity>();
                    Assert.True(companies.Count() >= 3);
                }
            }
        }
    }
}
