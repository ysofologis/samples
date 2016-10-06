using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ys.samples.infrastructure.auth;
using ys.samples.infrastructure.entities;
using ys.samples.services;

namespace ys.samples.infrastructure.users {
    internal class UserService : EFDomainService<UserModel,IUserEntity,UserModelAdapter>, IUserService {
        SessionRepository _sessionRepo;
        UserLoginRepository _loginRepo;
        public UserService( UserRepository entityRepo, 
            UserLoginRepository loginRepo,
            SessionRepository sessionRepo ) : base(entityRepo) {
            _sessionRepo = sessionRepo;
            _loginRepo = loginRepo;
        }
        public SessionModel getSession( IDomainServiceRequestContext reqctx, string userId ) {
            this.authService.authenticateRequest(reqctx);
            var userLogin = _loginRepo.Search(x => x.userId == userId).FirstOrDefault();
            var session = _sessionRepo.Search( x => x.userLoginId == userLogin.Id).FirstOrDefault() ;
            return new SessionModelAdapter().ModelFromEntity(session);
        }
    }
}
