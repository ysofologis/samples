using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ys.samples.dataaccess;

namespace ys.samples.services {
    public abstract class DomainServiceSkeleton<ModelT, EntityT, ModelAdapterT> : IDomainService, IDomainService<ModelT>
        where ModelT : IDomainModel
        where EntityT : class, IPersistentEntity
        where ModelAdapterT : ModelAdapter<ModelT, EntityT>, new() {

        protected EntityRepository<EntityT> _entityRepo;
        private ModelAdapterT _adapter;
        private IAuthenticationService _authService;
        public DomainServiceSkeleton( EntityRepository<EntityT> entityRepo ) {
            _adapter = new ModelAdapterT();
            _entityRepo = entityRepo;
        }
        public IAuthenticationService authService {
            get {
                return _authService;
            }
            set {
                _authService = value;
            }
        }
        void IDomainService.Delete( IDomainServiceRequestContext reqctx, string id ) {
            _authService.authenticateRequest(reqctx);
            var entity = _entityRepo.GetById(id);
            _entityRepo.Delete(entity);
        }

        IQueryable<IDomainModel> IDomainService.GetAll( IDomainServiceRequestContext reqctx, Paging paging ) {
            _authService.authenticateRequest(reqctx);
            return _entityRepo.GetAll(paging).ToList().Select(x => _adapter.ModelFromEntity(x)).Cast<IDomainModel>().AsQueryable();
        }

        IQueryable<IDomainModel> IDomainService.GetByFilter( IDomainServiceRequestContext reqctx, Filtering filtering, Paging paging ) {
            _authService.authenticateRequest(reqctx);
            return _entityRepo.GetByFilter(filtering, paging).Select(x => _adapter.ModelFromEntity(x)).Cast<IDomainModel>();
        }
        IDomainModel IDomainService.GetById( IDomainServiceRequestContext reqctx, string modelId ) {
            return this.GetById(reqctx, modelId);
        }

        void IDomainService.Update( IDomainServiceRequestContext reqctx, IDomainModel updatedModel ) {
            this.Update(reqctx, (ModelT) updatedModel);
        }

        void IDomainService.Add( IDomainServiceRequestContext reqctx, IDomainModel model ) {
            this.Add(reqctx, (ModelT) model);
        }

        void IDomainService.AddBatch( IDomainServiceRequestContext reqctx, IEnumerable<IDomainModel> models ) {
            this.AddBatch(reqctx, models.Cast<ModelT>());
        }

        public void Add( IDomainServiceRequestContext reqctx, ModelT model ) {
            this.authService.authenticateRequest(reqctx);
            _entityRepo.Insert(_adapter.EntityFromModel(_entityRepo, model));
        }
        void IDomainService<ModelT>.Add( IDomainServiceRequestContext reqctx, ModelT model ) {
            this.Add(reqctx, model);
        }
        public void AddBatch( IDomainServiceRequestContext reqctx, IEnumerable<ModelT> models ) {
            this.authService.authenticateRequest(reqctx);
            _entityRepo.InsertMany(models.Select(x => _adapter.EntityFromModel(_entityRepo, x)));
        }
        void IDomainService<ModelT>.AddBatch( IDomainServiceRequestContext reqctx, IEnumerable<ModelT> models ) {
            this.AddBatch(reqctx, models);
        }

        public IQueryable<ModelT> GetAll( IDomainServiceRequestContext reqctx, Paging paging ) {
            this.authService.authenticateRequest(reqctx);
            var data = _entityRepo.GetAll(paging).ToList();
            return data.Select(x => _adapter.ModelFromEntity(x)).AsQueryable();
        }
        IQueryable<ModelT> IDomainService<ModelT>.GetAll( IDomainServiceRequestContext reqctx, Paging paging ) {
            return this.GetAll(reqctx, paging);
        }

        IQueryable<ModelT> IDomainService<ModelT>.GetByFilter( IDomainServiceRequestContext reqctx, Filtering filtering, Paging paging ) {
            return _entityRepo.GetByFilter(filtering, paging).Select(x => _adapter.ModelFromEntity(x));
        }

        public ModelT GetById( IDomainServiceRequestContext reqctx, string modelId ) {
            _authService.authenticateRequest(reqctx);
            return _adapter.ModelFromEntity(_entityRepo.GetById(modelId));
        }
        ModelT IDomainService<ModelT>.GetById( IDomainServiceRequestContext reqctx, string modelId ) {
            return this.GetById(reqctx, modelId);
        }
        public void Update( IDomainServiceRequestContext reqctx, ModelT updatedModel ) {
            _authService.authenticateRequest(reqctx);
            var entity = _adapter.EntityFromModel(_entityRepo, updatedModel);
            _entityRepo.Update(entity);
        }
        void IDomainService<ModelT>.Update( IDomainServiceRequestContext reqctx, ModelT updatedModel ) {
            this.Update(reqctx, updatedModel);
        }
    }
}
