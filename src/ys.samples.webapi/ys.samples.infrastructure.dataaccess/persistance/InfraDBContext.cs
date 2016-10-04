using SQLite.CodeFirst;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ys.samples.infrastructure.entities;

namespace ys.samples.infrastructure.persistance {
    internal class InfraDBContext : DbContext {
        public InfraDBContext() : base("name=infrastructure-db") {

        }
        protected override void OnModelCreating( DbModelBuilder modelBuilder ) {
            base.OnModelCreating(modelBuilder);

            var sqliteConnectionInitializer = new SqliteCreateDatabaseIfNotExists<InfraDBContext>(modelBuilder);
            Database.SetInitializer(sqliteConnectionInitializer);

            //var dbModel = modelBuilder.Build(Database.Connection);
            //IDatabaseCreator sqliteDatabaseCreator = new SqliteDatabaseCreator();
            //sqliteDatabaseCreator.Create(Database, dbModel);

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
