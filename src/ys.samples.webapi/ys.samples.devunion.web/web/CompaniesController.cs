using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using ys.samples.web;

namespace ys.samples.devunion.web {
    [Route("api/companies")]
    public class CompaniesController : DomainServiceController<ICompanyService> {
    }
}
