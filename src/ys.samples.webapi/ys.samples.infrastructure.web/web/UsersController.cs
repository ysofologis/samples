using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using ys.samples.web;

namespace ys.samples.infrastructure.web {
    [RoutePrefix("api/users")]
    public class UsersController : DomainServiceController<IUserService> {
        [HttpGet]
        [Route("{id}/session")]
        public HttpResponseMessage getSession( string id ) {
            return processRequest(reqctx => {
                var session = this.apiService.getSession(reqctx,id);
                var hateoasModel = this.hateoasDecorator.DecorateModel(session);
                return this.Request.CreateResponse(System.Net.HttpStatusCode.OK, hateoasModel);
            });
        }
    }
}
