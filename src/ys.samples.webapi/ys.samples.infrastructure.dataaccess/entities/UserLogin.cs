using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ys.samples.dataaccess;

namespace ys.samples.infrastructure.entities {
    [AppTable("userlogins")]
    public class UserLogin : PersistentEntity {
        public string userPassword {
            get;set;
        }
        [Column("user_id")]
        public string userId {
            get;
            set;
        }
        public virtual User user {
            get;set;
        }
    }
}
