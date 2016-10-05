using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ys.samples.infrastructure.entities;
using ys.samples.services;

namespace ys.samples.infrastructure.auth {
    internal class AuthService : IAuthenticationService {
        private const string HEADER_SESSIONID = "session-id";

        private persistance.InfraPersistenceContext _perctx;
        private config.IConfigurationService _configService;
        public AuthService( persistance.InfraPersistenceContext perctx, config.IConfigurationService configService ) {
            _perctx = perctx;
        }
        public void AuthenticateRequest( IDomainServiceRequestContext reqctx ) {
            var headers = reqctx.GetHeaders();
            if ( headers.ContainsKey(HEADER_SESSIONID) ) {
                var sessionId = headers[HEADER_SESSIONID];
                var sessionSet = _perctx.GetEntitySet<UserSession>();
                var session = sessionSet.Find(sessionId);
                if ( session != null ) {
                    var totalMinutes = DateTime.Now.Subtract(session.LoginDate).TotalMinutes;
                    var sessionExpiration = int.Parse( _configService.GetSetting(config.AuthSetting.SessionExpiration) );
                    if ( totalMinutes > sessionExpiration ) {
                        throw new SessionExpiredException(sessionId);
                    }
                } else {
                    throw new SessionNotAuthenticatedException();
                }
            } else {
                throw new SessionNotAuthenticatedException();
            }
        }

        public void Login( IDomainServiceRequestContext reqctx ) {
            throw new NotImplementedException();
        }

        public void Logout( IDomainServiceRequestContext reqctx ) {
            throw new NotImplementedException();
        }
    }
}
