using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ys.samples.infrastructure.entities;
using ys.samples.infrastructure.users;
using ys.samples.services;

namespace ys.samples.infrastructure.auth {
    internal class AuthService : IAuthenticationService {
        private const string HEADER_SESSIONID = "session-id";
        private const string HEADER_AUTHORIZATION = "authorization";

        private SessionRepository _sessionRepo;
        private UserRepository _userRepo;
        private UserLoginRepository _userLoginRepo;
        private config.IConfigurationService _configService;
        public AuthService( SessionRepository repo, UserRepository userRepo, UserLoginRepository userLoginRepo, config.IConfigurationService configService ) {
            _sessionRepo = repo;
            _userRepo = userRepo;
            _userLoginRepo = userLoginRepo;
            _configService = configService;
        }
        public void authenticateRequest( IDomainServiceRequestContext reqctx ) {
            var headers = reqctx.GetHeaders();
            if ( headers.ContainsKey(HEADER_SESSIONID) ) {
                var sessionId = headers[HEADER_SESSIONID];
                var session = _sessionRepo.GetById(sessionId);
                if ( session != null ) {
                    var totalMinutes = DateTime.Now.Subtract(session.LoginDate).TotalMinutes;
                    var sessionExpiration = int.Parse( _configService.GetSetting(config.AuthSetting.SessionExpiration) );
                    if ( totalMinutes > sessionExpiration ) {
                        throw new ObjectExpiredException(sessionId);
                    }
                } else {
                    throw new NotAuthenticatedException();
                }
            } else {
                throw new NotAuthenticatedException();
            }
        }

        public string startSession( IDomainServiceRequestContext reqctx ) {
            var headers = reqctx.GetHeaders();
            if ( headers.ContainsKey(HEADER_AUTHORIZATION) ) {
                //Authorization: Basic QWxhZGRpbjpPcGVuU2VzYW1l
                var authParts = headers[HEADER_AUTHORIZATION].Split(' ');
                if ( authParts.Length == 2 ) {
                    var authType = authParts[0];
                    var authContent = Encoding.Default.GetString( Convert.FromBase64String(authParts[1]) ).Split(':');
                    if ( authType.ToLower() == "basic" ) {
                        if ( authContent.Length == 2 ) {
                            var user = _userRepo.Search(x => x.Name.Equals(authContent[0], StringComparison.CurrentCultureIgnoreCase) ).FirstOrDefault();
                            if ( user != null ) {
                                var userLogin = _userLoginRepo.Search(x => x.userId == user.Id).FirstOrDefault();
                                if ( userLogin != null ) {
                                    var existingSession = _sessionRepo.Search(x => x.userLoginId == userLogin.Id).FirstOrDefault();
                                    if ( userLogin.userPassword == authContent[1] ) {
                                        if ( existingSession != null ) {
                                            existingSession.LoginDate = DateTime.Now;
                                            _sessionRepo.Update(existingSession);
                                            return existingSession.Id;
                                        } else {
                                            var newSession = new UserSession() {
                                                LoginDate = DateTime.Now,
                                                userLogin = userLogin,
                                                LoginFailures = 0,
                                            };
                                            _sessionRepo.Insert(newSession);
                                            return newSession.Id;
                                        }
                                    } else {
                                        if ( existingSession != null ) {
                                            existingSession.LoginFailures++;
                                            _sessionRepo.Update(existingSession);
                                        }
                                        throw new NotAuthenticatedException("Invalid password");
                                    }
                                } else {
                                    throw new ObjectNotFoundException(string.Format("User '{0}' does not have a valid login record", authContent[0]));
                                }
                            } else {
                                throw new ObjectNotFoundException(string.Format("User '{0}' not found", authContent[0]));
                            }
                        } else {
                            throw new ExpectationFailedException("Auth credentials must be set in the format 'user:pass'");
                        }
                    } else {
                        throw new ExpectationFailedException("Only BASIC authentication is supported");
                    }
                } else {
                    throw new ExpectationFailedException("Authorization header has wrong format");
                }
            } else {
                throw new ExpectationFailedException("Authorization header not found");
            }
        }

        public void endSession( IDomainServiceRequestContext reqctx ) {
            throw new NotImplementedException();
        }
    }
}
