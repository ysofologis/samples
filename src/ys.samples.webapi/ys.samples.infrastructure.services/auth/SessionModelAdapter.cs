using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ys.samples.infrastructure.entities;
using ys.samples.services;

namespace ys.samples.infrastructure.auth {
    class SessionModelAdapter : ModelAdapter<SessionModel, UserSession> {
        public override UserSession EntityFromModel( SessionModel model ) {
            return new UserSession() {
                Id = model.Id,
                LoginDate = model.loginDate,
                LogoutDate = model.logoutDate,
                LoginFailures = model.loginFailures,
            };
        }

        public override SessionModel ModelFromEntity( UserSession entity ) {
            return new SessionModel() {
                Id = entity.Id,
                loginDate = entity.LoginDate,
                logoutDate = entity.LogoutDate,
                loginFailures = entity.LoginFailures,
                userId = entity.userLogin.userId,
            };
        }
    }
}
