using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using ys.samples.devunion.persistence;
using NHibernate.Engine;

namespace ys.samples.devunion {
    public class Module : Autofac.Module {
        protected override void Load( ContainerBuilder builder ) {
            base.Load(builder);
            builder.RegisterType<DataContext>().Named<IPersistenceContext>("devunion-context").InstancePerLifetimeScope();
        }
    }
}
