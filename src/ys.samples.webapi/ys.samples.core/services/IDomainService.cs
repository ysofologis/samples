using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ys.samples.services {
    public interface IDomainService {
        void Add( IDomainServiceRequestContext reqctx, IDomainModel model );
        void AddBatch( IDomainServiceRequestContext reqctx, IEnumerable<IDomainModel> models );
        IQueryable<IDomainModel> GetAll( IDomainServiceRequestContext reqctx, 
                                                Paging paging );
        IQueryable<IDomainModel> GetByFilter( IDomainServiceRequestContext reqctx, 
                                                Filtering filtering, 
                                                Paging paging );
        IDomainModel GetById( IDomainServiceRequestContext reqctx, 
                                                long modelId );
        void Update( IDomainServiceRequestContext reqctx, 
                                                long id, 
                                                IDomainModel updatedModel );
        void Delete( IDomainServiceRequestContext reqctx, 
                                                long id );
    }
}
