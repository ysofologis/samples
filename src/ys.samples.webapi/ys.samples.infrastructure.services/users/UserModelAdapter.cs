using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ys.samples.dataaccess;
using ys.samples.infrastructure.entities;
using ys.samples.services;

namespace ys.samples.infrastructure.users {
    internal class UserModelAdapter : ModelAdapter<UserModel,User> {
        public override User EntityFromModel( UserModel model ) {
            return new User() {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
            };
        }
        public override UserModel ModelFromEntity( User entity ) {
            return new UserModel() {
                Id = entity.Id,
                Email = entity.Email,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
            };
        }
    }
}
