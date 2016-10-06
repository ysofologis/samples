using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ys.samples.dataaccess;
using ys.samples.infrastructure.entities;
using ys.samples.services;

namespace ys.samples.infrastructure.auth {
    class SessionModelAdapter : ModelAdapter<SessionModel, IUserSessionEntity> {
        public override IUserSessionEntity EntityFromModel( IEntityFactory<IUserSessionEntity> entitySet, SessionModel model ) {
            var entity = entitySet.Create();
            entity.Id = model.Id;
            entity.LoginDate = model.loginDate;
            entity.LoginFailures = model.loginFailures;
            entity.LogoutDate = model.logoutDate;
            entity.userLoginId = model.userLoginId;
            return entity;
        }

        public override SessionModel ModelFromEntity( IUserSessionEntity entity ) {
            return new SessionModel() {
                Id = entity.Id,
                loginDate = entity.LoginDate,
                logoutDate = entity.LogoutDate,
                loginFailures = entity.LoginFailures,
                userLoginId = entity.userLoginId,
            };
        }
    }
}
