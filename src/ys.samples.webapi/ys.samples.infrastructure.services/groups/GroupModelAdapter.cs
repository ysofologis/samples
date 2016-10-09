using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ys.samples.dataaccess;
using ys.samples.infrastructure.entities;
using ys.samples.services;

namespace ys.samples.infrastructure.groups {
    internal class GroupModelAdapter : ModelAdapter<GroupModel, IGroupEntity> {
        public override IGroupEntity EntityFromModel( IEntityFactory<IGroupEntity> entitySet, GroupModel model ) {
            var entity = entitySet.Create();
            entity.id = model.Id;
            entity.Name = model.Name;
            return entity;
        }
        public override GroupModel ModelFromEntity( IGroupEntity entity ) {
            return new GroupModel() {
                Id = entity.id,
                Name = entity.Name,
            };
        }
    }
}
