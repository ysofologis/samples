using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ys.samples.config {
    public interface IConfigurationService {
        string GetSetting( ConfigurationSetting key );
    }
}
