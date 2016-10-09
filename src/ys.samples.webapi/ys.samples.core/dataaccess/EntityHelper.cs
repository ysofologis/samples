using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ys.samples.dataaccess {
    public static class EntityHelper {
        private const int ABBREVIATION_SIZE = 5;
        private static readonly DateTime centuryBegin = new DateTime(2001, 1, 1);
        private static readonly int processId = Process.GetCurrentProcess().Id;

        public static string createAbbreviation<EntityT>( this EntityT entity ) where EntityT : IPersistentEntity {
            var typeName = entity.GetType().Name;
            if ( typeName.Length >= ABBREVIATION_SIZE ) {
                var r = string.Format("{0}{1}{2}{3}{4}", typeName[0], 
                                                         typeName[1],
                                                         typeName[typeName.Length - 3],
                                                         typeName[typeName.Length - 2], 
                                                         typeName[typeName.Length - 1]);
                return r.ToUpper();
            } else {
                return typeName.PadRight(ABBREVIATION_SIZE, '@').ToUpper();
            }
        }
        public static EntityT makeUnique<EntityT>( this EntityT entity ) where EntityT : IPersistentEntity {
            if ( string.IsNullOrEmpty(entity.id) ) {
                var currentDate = DateTime.Now;
                long elapsedTicks = currentDate.Ticks - centuryBegin.Ticks;
                var uniqueId = string.Format("{0}{1}{2:X4}{3:X2}", entity.createAbbreviation(),
                                                                string.Format("{0:X}", currentDate.Ticks).PadLeft(16, '0'), 
                                                                processId, 
                                                                Thread.CurrentThread.ManagedThreadId)
                                                                .PadLeft(PersistentEntity.KEY_SIZE,'0');
                entity.id = uniqueId;
            }
            return entity;
        }
    }
}
