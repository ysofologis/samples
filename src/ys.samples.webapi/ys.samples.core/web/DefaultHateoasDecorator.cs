using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ys.samples.services;

namespace ys.samples.web {
    public class DefaultHateoasDecorator : IHateoasDecorator {
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
