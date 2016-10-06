using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using ys.samples.services;
using ys.samples.web;

namespace ys.samples.infrastructure.web {
    [RoutePrefix("api/sessions")]
    public class SessionsController : ServiceController<IAuthenticationService> {
        [Route("session")]
        [HttpPost]
        public HttpResponseMessage login( ) {
            return processRequest(( reqctx ) => {
                var sessionId = this.apiService.startSession(reqctx);
                return this.Request.CreateResponse(HttpStatusCode.Created, sessionId);
            });
        }
        [Route("session")]
        [HttpDelete]
        public HttpResponseMessage logout( ) {
            return processRequest(( reqctx ) => {
                this.apiService.endSession(reqctx);
                return this.Request.CreateResponse(HttpStatusCode.OK);
            });
        }
    }
}
