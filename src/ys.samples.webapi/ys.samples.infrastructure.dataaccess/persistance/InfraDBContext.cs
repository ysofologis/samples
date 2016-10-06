using SQLite.CodeFirst;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ys.samples.dataaccess;
using ys.samples.infrastructure.entities;

namespace ys.samples.infrastructure.persistance {
    internal class InfraDBContext : EFDataContext {
        private string _sqliteSchema;
        public InfraDBContext() : base("name=infrastructure-db") {
        }
        protected override void OnModelCreating( DbModelBuilder modelBuilder ) {
            base.OnModelCreating(modelBuilder);
            var sqliteConnectionInitializer = new SqliteCreateDatabaseIfNotExists<InfraDBContext>(modelBuilder);
            Database.SetInitializer(sqliteConnectionInitializer);

            if ( this.isSQLite ) {
                var model = modelBuilder.Build(Database.Connection);
                ISqlGenerator sqlGenerator = new SqliteSqlGenerator();
                _sqliteSchema = sqlGenerator.Generate(model.StoreModel);
            }
        }
        public bool isSQLite {
            get {
                return this.Database.Connection.GetType().ToString().ToLower().Contains("sqlite");
            }
        }
        public void createSchemaForSqlite( ) {
            using ( var cnn = new SQLiteConnection(this.Database.Connection.ConnectionString) ) {
                cnn.Open();
                using ( var cmd = cnn.CreateCommand() ) {
                    cmd.CommandText = _sqliteSchema;
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public DbSet<User> Users {
            get;set;
        }
        public DbSet<Group> Groups {
            get; set;
        }
        public DbSet<GroupMembership> UserGroups {
            get; set;
        }
        public DbSet<UserLogin> UserLogins {
            get; set;
        }
        public DbSet<UserSession> UserSessions {
            get; set;
        }
    }
}
