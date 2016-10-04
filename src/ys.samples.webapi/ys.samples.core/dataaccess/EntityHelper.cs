using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ys.samples.dataaccess {
    public static class EntityHelper {
        private static readonly DateTime centuryBegin = new DateTime(2001, 1, 1);
        private static readonly int processId = Process.GetCurrentProcess().Id;

        public static EntityT makeUnique<EntityT>( this EntityT entity ) where EntityT : IPersistentEntity {
            if ( string.IsNullOrEmpty(entity.Id) ) {
                var currentDate = DateTime.Now;
                long elapsedTicks = currentDate.Ticks - centuryBegin.Ticks;
                var uniqueId = string.Format("{0:X10}{1:X4}{2:X2}", elapsedTicks, processId, Thread.CurrentThread.ManagedThreadId).PadLeft(PersistentEntity.KEY_SIZE,'0');
                entity.Id = uniqueId;
            }
            return entity;
        }
    }
}
