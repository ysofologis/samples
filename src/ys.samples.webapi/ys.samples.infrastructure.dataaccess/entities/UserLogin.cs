using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ys.samples.dataaccess;

namespace ys.samples.infrastructure.entities {
    public interface IUserLoginEntity : IPersistentEntity {
        string userPassword {
            get;
            set;
        }
        string userId {
            get;
            set;
        }
    }
    [AppTable("userlogins")]
    internal class UserLogin : PersistentEntity, IUserLoginEntity {
        public string userPassword {
            get;set;
        }
        [Column("user_id")]
        [StringLength(KEY_SIZE)]
        public string userId {
            get;
            set;
        }
        public virtual User user {
            get;set;
        }
    }
}
