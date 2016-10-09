using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ys.samples.dataaccess;
using ys.samples.devunion.entities;
using ys.samples.devunion.persistence;

namespace ys.samples.devunion.companies {
    internal class CompanyRepository : EntityRepository<ICompanyEntity> {
        public CompanyRepository( DevunionPersistenceContext perctx) : base(perctx) {
            
        }
    }
}
