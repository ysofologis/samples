using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ys.samples.devunion.entities;
using ys.samples.devunion.persistence;
using ys.samples.services;

namespace ys.samples.devunion.companies {
    internal class CompanyService : DomainServiceSkeleton<CompanyModel,ICompanyEntity,CompanyAdapter>, 
        ICompanyService {
        public CompanyService( CompanyRepository repo ) : base(repo) {

        }
    }
}
