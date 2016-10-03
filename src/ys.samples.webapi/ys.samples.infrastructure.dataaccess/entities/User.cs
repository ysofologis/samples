using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ys.samples.devunion.entities {
    [AppTable("users")]
    public class User {
        public long Id {
            get;
            set;
        }
    }
}
