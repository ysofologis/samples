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

    public class ServiceController<ServiceT> : ApiController {
        public ServiceController( ) {
        }
        public IHateoasDecorator hateoasDecorator {
            get;
            set;
        }
        public ServiceT apiService {
            get; set;
        }
        protected HttpResponseMessage processRequest( Func<IDomainServiceRequestContext, HttpResponseMessage> func ) {
            try {
                return func(new WebAPIDomainServiceRequestContext(this));
            }catch( NotAuthenticatedException  x) {
                return this.Request.CreateResponse(HttpStatusCode.Unauthorized, this.hateoasDecorator.DecorateException(x));
            } catch ( ObjectExpiredException x ) {
                return this.Request.CreateResponse(HttpStatusCode.Unauthorized, this.hateoasDecorator.DecorateException(x));
            } catch ( Exception x ) {
                return this.Request.CreateResponse(HttpStatusCode.InternalServerError, this.hateoasDecorator.DecorateException(x));
            }
        }
    }
    public abstract class DomainServiceController<ServiceT> : ServiceController<ServiceT>
        where ServiceT : IDomainService  {
        [HttpGet]
        [Route("")]
        public HttpResponseMessage GetAll( int? page = null, int? pageSize = null ) {
            return doGetAll(page, pageSize);
        }
        protected virtual HttpResponseMessage doGetAll( int? page = null, int? pageSize = null ) {
            return processRequest(( reqctx ) => {
                var paging = new Paging() { page = page, pageSize = pageSize };
                var items = this.apiService.GetAll(reqctx, paging);
                var hateoasModel = this.hateoasDecorator.DecorateModel(items, paging);
                return this.Request.CreateResponse(System.Net.HttpStatusCode.OK, hateoasModel);
            });
        }
        [HttpGet]
        [Route("{id}")]
        public HttpResponseMessage Get( string id ) {
            return doGet(id);
        }

        protected virtual HttpResponseMessage doGet( string id ) {
            return processRequest(( reqctx ) => {
                var hateoasModel = this.hateoasDecorator.DecorateModel(this.apiService.GetById(reqctx, id));
                return this.Request.CreateResponse(System.Net.HttpStatusCode.OK, hateoasModel);
            });
        }
    }
}
