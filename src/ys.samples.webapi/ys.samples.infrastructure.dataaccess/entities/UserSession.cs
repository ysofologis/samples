using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ys.samples.dataaccess;

namespace ys.samples.infrastructure.entities {
    public interface IUserSessionEntity : IPersistentEntity {
        DateTime LoginDate {
            get;
            set;
        }
        DateTime LogoutDate {
            get;
            set;
        }
        int LoginFailures {
            get;
            set;
        }
        string userLoginId {
            get;
            set;
        }
        IUserLoginEntity getUserLogin( );
    }
    [AppTable("usersessions")]
    internal class UserSession : PersistentEntity, IUserSessionEntity {
        public DateTime LoginDate {
            get;
            set;
        }
        public DateTime LogoutDate {
            get;
            set;
        }
        public int LoginFailures {
            get;
            set;
        }
        [Column("user_login_id")]
        [StringLength(KEY_SIZE)]
        public string userLoginId {
            get;
            set;
        }
        public virtual UserLogin userLogin {
            get;
            set;
        }
        public IUserLoginEntity getUserLogin( ) {
            return this.userLogin;
        }
    }
}
