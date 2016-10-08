using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ys.samples.dataaccess;

namespace ys.samples.infrastructure.entities {
    public interface IGroupEntity : IPersistentEntity {
        string Name {
            get;
            set;
        }
    }
    [AppTable("groups")]
    internal class Group : PersistentEntity, IGroupEntity {
        [Index(IsUnique=true)]
        [StringLength(50)]
        public string Name {
            get;
            set;
        }
    }
}
