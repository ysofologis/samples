﻿using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ys.samples.infrastructure.persistance;

namespace ys.samples.infrastructure {
    internal class Module : Autofac.Module {
        protected override void Load( ContainerBuilder builder ) {
            base.Load(builder);
            builder.RegisterType<InfraDBContext>().InstancePerLifetimeScope();
            builder.RegisterType<InfraPersistenceContext>().InstancePerLifetimeScope();
        }
    }
}