using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ys.samples.config {
    public sealed class PersistenceSetting : ConfigurationSetting {
        private PersistenceSetting(string name, string defaultValue): base(name,defaultValue) {

        }
        public const string ENGINE_ENTITY_FRAMEWORK = "EF";
        public const string ENGINE_NHIBERNATE = "NHIBERNATE";
        public const string ENGINE_DAPPER = "DAPPER";
        public const string ENGINE_PETAPOCCO = "DAPPER";

        public static readonly PersistenceSetting persistenceEngine = new PersistenceSetting("persistence:engine", ENGINE_ENTITY_FRAMEWORK);
        public static readonly PersistenceSetting persistenceSetup = new PersistenceSetting("persistence:setup", "web.config");
    }
}
