using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ys.samples.services;

namespace ys.samples.web {
    public class DefaultHateoasDecorator : IHateoasDecorator {
        private Exception getRootException( Exception x ) {
            if ( x.InnerException == null ) {
                return x;
            } else {
                return getRootException(x);
            }
        }
        public HateoasModel DecorateException( Exception x ) {
            var rootEx = getRootException(x);
            return new HateoasModel() {
                error = new HateoasModel.ErrorInfo() {
                    message = x.Message,
                    type = x.GetType().FullName,
                    stackTrace = x.StackTrace,
                    rootCause = rootEx.Message,
                }
            };
        }

        public HateoasModel DecorateModel( IDomainModel domainModel ) {
            return new HateoasModel() {
                content = new HateoasModel.ResourceItem[] {
                    new HateoasModel.ResourceItem() {
                        item = domainModel
                    }
                },
            };
        }

        public HateoasModel DecorateModel( IQueryable<IDomainModel> domainModel, Paging paging ) {
            var resourceItems = domainModel.Select(x => new HateoasModel.ResourceItem() {
                item = x
            });
            return new HateoasModel() {
                content = resourceItems
            };
        }
    }
}
