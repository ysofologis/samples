using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using ys.samples.ioc;
using ys.samples.devunion.persistence;
using ys.samples.devunion.entities;

namespace ys.samples.devunion {
    internal class ModuleSetup : IModuleSetup {
        public void setupModule( IContainer iocResolver ) {
            using ( var perctx = iocResolver.Resolve<DevunionPersistenceContext>() ) {
                using ( var work = perctx.StartWork(false) ) {
                    addKnownCompanies(perctx);
                    work.Save();
                }
            }
        }
        private void addKnownCompanies( DevunionPersistenceContext perctx ) {
            var companies = perctx.GetEntitySet<ICompanyEntity>();
            if ( companies.Count() == 0 ) {
                companies.Add(new Company() {
                    name = "newsphone hellas",
                    sobriquet = "oldphone",
                    dateInserted = DateTime.Now,
                    dateUpdated = DateTime.Now,
                    address = "Odyssews 180"
                });
            }
        }
    }
}
