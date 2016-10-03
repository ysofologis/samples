using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using ys.samples.services;

namespace ys.samples.web {
    public class WebAPIDomainServiceRequestContext : IDomainServiceRequestContext {
        private HttpRequestContext _httpRequestContext;
        public WebAPIDomainServiceRequestContext( HttpRequestContext httpRequestContext ) {
            _httpRequestContext = httpRequestContext;
        }
        public Dictionary<string, string> GetHeaders( ) {
            throw new NotImplementedException();
        }
    }
}
