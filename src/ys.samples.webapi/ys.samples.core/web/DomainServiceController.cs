using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using ys.samples.services;

namespace ys.samples.web {
    public abstract class DomainServiceController<ServiceT> : ApiController
        where ServiceT : IDomainService  {
        public IDomainService domainService {
            get;set;
        }
        public IHateoasDecorator hateoasDecorator {
            get;
            set;
        }
        protected HttpResponseMessage processRequest( Func<IDomainServiceRequestContext,HttpResponseMessage> func ) {
            try {
                return func(new WebAPIDomainServiceRequestContext(this));
            }catch(Exception x) {
                return this.Request.CreateResponse(HttpStatusCode.InternalServerError, this.hateoasDecorator.DecorateException(x));
            }
        }
        [HttpGet]
        [Route("")]
        public HttpResponseMessage GetAll( int? page = null, int? pageSize = null ) {
            return processRequest(( reqctx ) => {
                var paging = new Paging() { page = page, pageSize = pageSize };
                var items = this.domainService.GetAll(reqctx, paging);
                var hateoasModel = this.hateoasDecorator.DecorateModel(items, paging);
                return this.Request.CreateResponse(System.Net.HttpStatusCode.OK, hateoasModel);
            });
        }
        [HttpGet]
        [Route("{id}")]
        public HttpResponseMessage Get( string id ) {
            return processRequest(( reqctx ) => {
                var hateoasModel = this.hateoasDecorator.DecorateModel(this.domainService.GetById(reqctx, id));
                return this.Request.CreateResponse(System.Net.HttpStatusCode.OK, hateoasModel);
            });
        }
    }
}
