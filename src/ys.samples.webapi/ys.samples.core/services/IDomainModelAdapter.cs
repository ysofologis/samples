using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ys.samples.dataaccess;

namespace ys.samples.services {
    public interface IDomainModelAdapter {
        IDomainModel ModelFromEntity( IPersistentEntity entity );
        IPersistentEntity EntityFromModel( IDomainModel model );
    }

    public abstract class ModelAdapter<ModelT, EntityT> : IDomainModelAdapter
        where ModelT : IDomainModel
        where EntityT : class, IPersistentEntity, new() {
        public abstract EntityT EntityFromModel( ModelT model );
        IPersistentEntity IDomainModelAdapter.EntityFromModel( IDomainModel model ) {
            return this.EntityFromModel( (ModelT) model);
        }

        public abstract ModelT ModelFromEntity( EntityT entity );
        IDomainModel IDomainModelAdapter.ModelFromEntity( IPersistentEntity entity ) {
            return this.ModelFromEntity((EntityT)entity);
        }
    }
}
