using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ys.samples.dataaccess;

namespace ys.samples.services {
    public abstract class EFDomainService<ModelT,EntityT, ModelAdapterT> : IDomainService
        where ModelT : IDomainModel 
        where EntityT : class, IPersistentEntity
        where ModelAdapterT : IDomainModelAdapter, new() {
        private EFEntityRepository<EntityT> _entityRepo;
        private ModelAdapterT _adapter;
        public EFDomainService( ) {
            _adapter = new ModelAdapterT();
        }
        void IDomainService.Delete( IDomainServiceRequestContext reqctx, long id ) {
            var entity = _entityRepo.GetById(id);
            _entityRepo.Delete(entity);
        }

        IQueryable<IDomainModel> IDomainService.GetAll( IDomainServiceRequestContext reqctx, Paging paging ) {
            throw new NotImplementedException();
        }

        IQueryable<IDomainModel> IDomainService.GetByFilter( IDomainServiceRequestContext reqctx, Filtering filtering, Paging paging ) {
            throw new NotImplementedException();
        }

        IDomainModel IDomainService.GetById( IDomainServiceRequestContext reqctx, long modelId ) {
            throw new NotImplementedException();
        }

        void IDomainService.Update( IDomainServiceRequestContext reqctx, long id, IDomainModel updatedModel ) {
            throw new NotImplementedException();
        }

        void IDomainService.Add( IDomainServiceRequestContext reqctx, IDomainModel model ) {
            throw new NotImplementedException();
        }

        void IDomainService.AddBatch( IDomainServiceRequestContext reqctx, IEnumerable<IDomainModel> models ) {
            throw new NotImplementedException();
        }
    }
}
