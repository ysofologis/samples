using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ys.samples.dataaccess;

namespace ys.samples.services {
    public interface IDomainModelAdapter {
        IDomainModel ModelFromEntity( IPersistentEntity entity );
        IPersistentEntity EntityFromModel( IEntityFactory<IPersistentEntity> entitySet, IDomainModel model );
    }

    public abstract class ModelAdapter<ModelT, EntityT> : IDomainModelAdapter
        where ModelT : IDomainModel
        where EntityT : class, IPersistentEntity {
        public abstract EntityT EntityFromModel( IEntityFactory<EntityT> factory, ModelT model );
        IPersistentEntity IDomainModelAdapter.EntityFromModel( IEntityFactory<IPersistentEntity> factory, IDomainModel model ) {
            return this.EntityFromModel( (IEntitySet<EntityT>) factory, (ModelT) model);
        }

        public abstract ModelT ModelFromEntity( EntityT entity );
        IDomainModel IDomainModelAdapter.ModelFromEntity( IPersistentEntity entity ) {
            return this.ModelFromEntity((EntityT)entity);
        }
    }
}
