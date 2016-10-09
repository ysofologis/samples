using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ys.samples.services;

namespace ys.samples.devunion {
    public class CompanyModel : IDomainModel {
        public string Id {
            get;set;
        }
    }
    public interface ICompanyService : IDomainService<CompanyModel> {
    }
}
