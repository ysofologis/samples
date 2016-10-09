using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ys.samples.dataaccess;
using ys.samples.devunion.entities;
using ys.samples.services;

namespace ys.samples.devunion.companies {
    internal class CompanyAdapter : ModelAdapter<CompanyModel, ICompanyEntity> {
        public override ICompanyEntity EntityFromModel( IEntityFactory<ICompanyEntity> factory, CompanyModel model ) {
            var entity = factory.Create();
            entity.id = model.id;
            entity.address = model.address;
            entity.name = model.name;
            entity.sobriquet = model.sobriquet;
            return entity;
        }

        public override CompanyModel ModelFromEntity( ICompanyEntity entity ) {
            return new CompanyModel() {
                id = entity.id,
                address = entity.address,
                dateInserted = entity.dateInserted,
                dateUpdated = entity.dateUpdated,
                name = entity.name,
                sobriquet = entity.sobriquet,
                updatedBy = entity.updatedById,
            };
        }
    }
}
