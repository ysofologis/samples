using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ys.samples.infrastructure.entities;
using ys.samples.services;

namespace ys.samples.infrastructure.groups {
    internal class GroupModelAdapter : ModelAdapter<GroupModel, entities.Group> {
        public override Group EntityFromModel( GroupModel model ) {
            return new Group() {
                Id = model.Id,
                Name = model.Name,
            };
        }
        public override GroupModel ModelFromEntity( Group entity ) {
            return new GroupModel() {
                Id = entity.Id,
                Name = entity.Name,
            };
        }
    }
}
