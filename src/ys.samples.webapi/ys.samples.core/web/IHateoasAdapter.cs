using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ys.samples.services;

namespace ys.samples.web {
    public interface IHateoasAdapter {
        HateoasModel ToHateoas( IDomainModel domainModel );
        HateoasModel ToHateoas( IQueryable<IDomainModel> domainModel, Paging paging );
    }
}
