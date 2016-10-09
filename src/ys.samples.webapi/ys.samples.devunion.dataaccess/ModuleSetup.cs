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
                addKnownCompanies(perctx);
                perctx.Save();
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
                companies.Add(new Company() {
                    name = "codix",
                    sobriquet = "sodix",
                    dateInserted = DateTime.Now,
                    dateUpdated = DateTime.Now,
                    address = "Tolonos 180"
                });
                companies.Add(new Company() {
                    name = "unixfor",
                    sobriquet = "linuxfor",
                    dateInserted = DateTime.Now,
                    dateUpdated = DateTime.Now,
                    address = "Agrioupolews 180"
                });
                companies.Add(new Company() {
                    name = "relational",
                    sobriquet = "irrelational",
                    dateInserted = DateTime.Now,
                    dateUpdated = DateTime.Now,
                    address = "Kipokratous 180"
                });
            }
        }
    }
}
