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
                                                string modelId );
        void Update( IDomainServiceRequestContext reqctx, 
                                                IDomainModel updatedModel );
        void Delete( IDomainServiceRequestContext reqctx, 
                                                string id );
    }
    public interface IDomainService<ModelT> : IDomainService
        where ModelT: IDomainModel {
        void Add( IDomainServiceRequestContext reqctx, ModelT model );
        void AddBatch( IDomainServiceRequestContext reqctx, IEnumerable<ModelT> models );
        new IQueryable<ModelT> GetAll( IDomainServiceRequestContext reqctx,
                                                Paging paging );
        new IQueryable<ModelT> GetByFilter( IDomainServiceRequestContext reqctx,
                                                Filtering filtering,
                                                Paging paging );
        new ModelT GetById( IDomainServiceRequestContext reqctx,
                                                string modelId );
        void Update( IDomainServiceRequestContext reqctx,
                                                ModelT updatedModel );
    }
}
