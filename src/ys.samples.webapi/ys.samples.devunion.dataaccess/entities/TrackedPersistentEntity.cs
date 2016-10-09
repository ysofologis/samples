using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ys.samples.dataaccess;
using NHibernate.Engine;

namespace ys.samples.devunion.entities {
    public interface ITrackedEntity : IPersistentEntity {
        string updatedById {
            get;
            set;
        }
        string historyHead {
            get;
            set;
        }
        int historyRevision {
            get;set;
        }
        bool isDeleted {
            get;
            set;
        }
        void markAsDiscarded( string memberId, ITrackedEntity prevRevision );
        void markAsDeleted( string memberId );
    }
    internal abstract class TrackedPersistentEntity : ITrackedEntity {
        public virtual string id {
            get;
            set;
        }
        public virtual DateTime? dateInserted {
            get;
            set;
        }
        public virtual DateTime? dateUpdated {
            get;
            set;
        }
        public virtual string updatedById {
            get;
            set;
        }
        public virtual Member updatedBy {
            get;
            set;
        }
        public virtual string historyHead {
            get;
            set;
        }
        public virtual int historyRevision {
            get;
            set;
        }
        public virtual bool isDeleted {
            get;
            set;
        }
        public virtual void markAsDiscarded( string memberId, ITrackedEntity prevRevision ) {
            this.updatedById = memberId;
            this.historyRevision = prevRevision != null ? prevRevision.historyRevision + 1 : 1;
            this.historyHead = prevRevision != null ? prevRevision.historyHead : this.id;
        }

        public virtual void markAsDeleted( string memberId ) {
            this.isDeleted = true;
            this.updatedById = memberId;
        }
    }
    internal class LocalIdGenerator : NHibernate.Id.IIdentifierGenerator {
        public object Generate( ISessionImplementor session, object obj ) {
            var entity = (IPersistentEntity) obj;
            entity.makeUnique();
            return entity.id;
        }
    }
    internal abstract class EntityMap<EntityT> : ClassMap<EntityT>
        where EntityT : TrackedPersistentEntity {
        public EntityMap( ) {
            Id(x => x.id).GeneratedBy.Custom<LocalIdGenerator>();
            Map(x => x.dateInserted, "date_inserted").Nullable();
            Map(x => x.dateUpdated, "date_updated").Nullable();
            Map(x => x.historyHead, "history_head").Nullable();
            Map(x => x.historyRevision, "history_rev").Default("0");
            Map(x => x.isDeleted, "is_deleted").Default("0");
            References<Member>(x => x.updatedBy).Column("updated_by").Nullable().Cascade.All();
        }
    }

}
