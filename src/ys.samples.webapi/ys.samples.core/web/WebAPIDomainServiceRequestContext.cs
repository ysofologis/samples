using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using ys.samples.services;

namespace ys.samples.web {
    public class WebAPIDomainServiceRequestContext : IDomainServiceRequestContext {
        private HttpRequestContext _httpRequestContext;
        private HttpRequestMessage _httpRequestMessage;
        public WebAPIDomainServiceRequestContext( ApiController controller) {
            _httpRequestContext = controller.ControllerContext.RequestContext;
            _httpRequestMessage = controller.ControllerContext.Request;
        }

        public IPrincipal User {
            get;set;
        }

        public Dictionary<string, string> GetHeaders( ) {
            var dict = new Dictionary<string, string>();
            foreach ( var x in _httpRequestMessage.Headers ) {
                dict.Add(x.Key.ToLower(), x.Value.First());
            }
            return dict;
        }
    }
}
