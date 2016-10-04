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
    public class UsersController : ApiController {
        public UsersController( ) {
        }
        public IUserService domainService {
            get;
            set;
        }
        public IHateoasDecorator hateoasDecorator {
            get;
            set;
        }
        [HttpGet]
        [Route("")]
        public HttpResponseMessage GetAll( int? page = null, int? pageSize = null ) {
            var reqctx = new WebAPIDomainServiceRequestContext(this.RequestContext);
            var paging = new Paging() { page = page, pageSize = pageSize };
            var items = this.domainService.GetAll(reqctx, paging);
            var hateoasModel = this.hateoasDecorator.DecorateModel(items, paging);
            return this.Request.CreateResponse(System.Net.HttpStatusCode.OK, hateoasModel);
        }
        [HttpGet]
        [Route("{id}")]
        public HttpResponseMessage Get( string id ) {
            var reqctx = new WebAPIDomainServiceRequestContext(this.RequestContext);
            var hateoasModel = this.hateoasDecorator.DecorateModel(this.domainService.GetById(reqctx, id));
            return this.Request.CreateResponse(System.Net.HttpStatusCode.OK, hateoasModel);
        }
    }
}
