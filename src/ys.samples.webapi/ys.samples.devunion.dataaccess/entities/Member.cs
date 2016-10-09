using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ys.samples.dataaccess;

namespace ys.samples.devunion.entities {
    public interface IMemberEntity : IPersistentEntity {
        string nickname {
            get;
            set;
        }
        string userId {
            get;
            set;
        }
        string jobTitle {
            get;
            set;
        }
    }
    internal class Member : PersistentEntity, IMemberEntity {
        public virtual string nickname {
            get;
            set;
        }
        public virtual string userId {
            get;
            set;
        }
        public virtual string jobTitle {
            get;set;
        }
    }
    internal class MemberMap : ClassMap<Member> {
        public MemberMap( ) {
            Id(x => x.id).GeneratedBy.Custom<LocalIdGenerator>();
            Map(x => x.dateInserted, "date_inserted").Nullable();
            Map(x => x.dateUpdated, "date_updated").Nullable();
            Map(x => x.userId, "user_id").Not.Nullable();
            Map(x => x.jobTitle, "job_title").Not.Nullable();
        }
    }
}
