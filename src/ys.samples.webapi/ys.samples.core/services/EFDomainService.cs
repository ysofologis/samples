using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ys.samples.dataaccess;

namespace ys.samples.services {
    public abstract class EFDomainService<ModelT,EntityT, ModelAdapterT> : IDomainService, IDomainService<ModelT>
        where ModelT : IDomainModel 
        where EntityT : class, IPersistentEntity, new()
        where ModelAdapterT : ModelAdapter<ModelT,EntityT>, new() {

        private EFEntityRepository<EntityT> _entityRepo;
        private ModelAdapterT _adapter;
        private IAuthenticationService _authService;
        public EFDomainService( EFEntityRepository<EntityT> entityRepo ) {
            _adapter = new ModelAdapterT();
            _entityRepo = entityRepo;
        }
        void IDomainService.Delete( IDomainServiceRequestContext reqctx, string id ) {
            _authService.AuthenticateRequest(reqctx);
            var entity = _entityRepo.GetById(id);
            _entityRepo.Delete(entity);
        }

        IQueryable<IDomainModel> IDomainService.GetAll( IDomainServiceRequestContext reqctx, Paging paging ) {
            _authService.AuthenticateRequest(reqctx);
            return _entityRepo.GetAll(paging).Select( x => _adapter.ModelFromEntity(x) ).Cast<IDomainModel>();
        }

        IQueryable<IDomainModel> IDomainService.GetByFilter( IDomainServiceRequestContext reqctx, Filtering filtering, Paging paging ) {
            _authService.AuthenticateRequest(reqctx);
            return _entityRepo.GetByFilter(filtering, paging).Select(x => _adapter.ModelFromEntity(x)).Cast<IDomainModel>();
        }

        IDomainModel IDomainService.GetById( IDomainServiceRequestContext reqctx, string modelId ) {
            _authService.AuthenticateRequest(reqctx);
            return _adapter.ModelFromEntity( _entityRepo.GetById(modelId) );
        }

        void IDomainService.Update( IDomainServiceRequestContext reqctx, string id, IDomainModel updatedModel ) {
            throw new NotImplementedException();
        }

        void IDomainService.Add( IDomainServiceRequestContext reqctx, IDomainModel model ) {
            throw new NotImplementedException();
        }

        void IDomainService.AddBatch( IDomainServiceRequestContext reqctx, IEnumerable<IDomainModel> models ) {
            throw new NotImplementedException();
        }

        void IDomainService<ModelT>.Add( IDomainServiceRequestContext reqctx, ModelT model ) {
            throw new NotImplementedException();
        }

        void IDomainService<ModelT>.AddBatch( IDomainServiceRequestContext reqctx, IEnumerable<ModelT> models ) {
            throw new NotImplementedException();
        }

        IQueryable<ModelT> IDomainService<ModelT>.GetAll( IDomainServiceRequestContext reqctx, Paging paging ) {
            throw new NotImplementedException();
        }

        IQueryable<ModelT> IDomainService<ModelT>.GetByFilter( IDomainServiceRequestContext reqctx, Filtering filtering, Paging paging ) {
            throw new NotImplementedException();
        }

        ModelT IDomainService<ModelT>.GetById( IDomainServiceRequestContext reqctx, string modelId ) {
            _authService.AuthenticateRequest(reqctx);
            return _adapter.ModelFromEntity(_entityRepo.GetById(modelId));
        }

        void IDomainService<ModelT>.Update( IDomainServiceRequestContext reqctx, string id, ModelT updatedModel ) {
            throw new NotImplementedException();
        }
    }
}
