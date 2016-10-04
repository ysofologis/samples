﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using ys.samples.web;

namespace ys.samples {
    public class Module : Autofac.Module {
        protected override void Load( ContainerBuilder builder ) {
            base.Load(builder);
            builder.RegisterType<DefaultHateoasDecorator>().As<IHateoasDecorator>().InstancePerDependency();
        }
    }
}