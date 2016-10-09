using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ys.samples.config {
    internal class AppSettingConfigService : IConfigurationService {
        public string GetSetting( ConfigurationSetting setting ) {
            if ( ConfigurationManager.AppSettings[setting.Key] != null ) {
                return ConfigurationManager.AppSettings[setting.Key];
            } else {
                return setting.defaultValue;
            }
        }
    }
}
