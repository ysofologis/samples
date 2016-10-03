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
        protected static readonly DateTime centuryBegin = new DateTime(2001, 1, 1);

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [StringLength(maximumLength:50,MinimumLength =50)]
        public string Id {
            get;
            set;
        }

        public void MakeUnique( ) {
            var currentDate = DateTime.Now;
            long elapsedTicks = currentDate.Ticks - centuryBegin.Ticks;
            var uniqueId = string.Format("{0:N0}-{1:D4}-{2:D3}", elapsedTicks, Process.GetCurrentProcess().Id, Thread.CurrentThread.ManagedThreadId );
            this.Id = uniqueId;
        }
    }
}
