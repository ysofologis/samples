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
        public const int KEY_SIZE = 27;
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [StringLength(KEY_SIZE)]
        public string id {
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
