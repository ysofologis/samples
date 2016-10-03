using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ys.samples.dataaccess;

namespace ys.samples.services {
    public interface IDomainModelAdapter {
        IDomainModel ModelFromEntity( IPersistentEntity entity );
        IPersistentEntity EntityFromModel( IDomainModel model );
    }
}
