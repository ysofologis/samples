using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ys.samples.services;

namespace ys.samples.infrastructure.services {
    public interface IUserService : IDomainService {
        IQueryable<UserModel> GetUsers( );
        UserModel GetUser( long userId );
        void UpdateUser( long userId, UserModel user );
        void DeleteUser( long userId );
    }
}
