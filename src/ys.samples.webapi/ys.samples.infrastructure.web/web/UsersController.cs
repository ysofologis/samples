using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using ys.samples.web;

namespace ys.samples.infrastructure.web {
    public class UsersController : ApiController {
        public IUserService domainService {
            get;
            set;
        }
        public IHateoasDecorator hateoasDecorator {
            get;
            set;
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
