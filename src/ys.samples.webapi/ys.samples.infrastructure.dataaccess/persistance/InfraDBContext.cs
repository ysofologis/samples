using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ys.samples.infrastructure.entities;

namespace ys.samples.infrastructure.persistance {
    internal class InfraDBContext : DbContext {
        public InfraDBContext() : base("infra") {

        }
        public virtual DbSet<User> Users {
            get;set;
        }
        public virtual DbSet<Group> Groups {
            get; set;
        }
        public virtual DbSet<GroupMembership> UserGroups {
            get; set;
        }
        public virtual DbSet<UserLogin> UserLogins {
            get; set;
        }
        public virtual DbSet<UserSession> UserSessions {
            get; set;
        }
    }
}
