using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ys.samples.config {
    public sealed class AuthSetting : ConfigurationSetting {
        private AuthSetting(string name): base(name) {

        }
        public static readonly AuthSetting SessionExpiration = new AuthSetting("auth:session-expiration");
    }
}
