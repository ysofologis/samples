using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ys.samples.services;

namespace ys.samples.web {
    public interface IHateoasDecorator {
        HateoasModel DecorateModel( IDomainModel domainModel );
        HateoasModel DecorateModel( IQueryable<IDomainModel> domainModel, Paging paging );
    }
}
