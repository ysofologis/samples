using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ys.samples.dataaccess {
    public abstract class PersistentEntity : IPersistentEntity {
        public const int KEY_SIZE = 16;
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [StringLength(maximumLength: KEY_SIZE, MinimumLength = KEY_SIZE)]
        public string Id {
            get;
            set;
        }
        public DateTime? dateInserted {
            get;set;
        }
        public DateTime? dateUpdated {
            get; set;
        }
    }
}
