using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ys.samples.dataaccess;
using ys.samples.infrastructure.entities;
using ys.samples.services;

namespace ys.samples.infrastructure.users {
    internal class UserModelAdapter : ModelAdapter<UserModel,IUserEntity> {
        public override IUserEntity EntityFromModel( IEntityFactory<IUserEntity> factory, UserModel model ) {
            var entity = factory.Create();
            entity.id = model.Id;
            entity.Name = model.Name;
            entity.FirstName = model.FirstName;
            entity.LastName = model.LastName;
            entity.Email = model.Email;
            return entity;
        }
        public override UserModel ModelFromEntity( IUserEntity entity ) {
            return new UserModel() {
                Id = entity.id,
                Name = entity.Name,
                Email = entity.Email,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
            };
        }
    }
}
