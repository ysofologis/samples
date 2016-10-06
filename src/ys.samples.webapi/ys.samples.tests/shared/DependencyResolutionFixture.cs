﻿using Autofac;
using Autofac.Configuration;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ys.samples.dataaccess;

namespace ys.samples.shared {
    public class DependencyResolutionFixture : IDisposable {
        public IContainer resolver {
            get;
            private set;
        }
        public DependencyResolutionFixture( ) {
            var builder = new Autofac.ContainerBuilder();
            
            var config = new ConfigurationBuilder();
            config.AddJsonFile("autofac.json");
            var module = new ConfigurationModule(config.Build());
            builder.RegisterModule(module);

            builder.RegisterType<InMemoryPersistentContext>().As<IPersistenceContext>().InstancePerLifetimeScope();

            this.resolver = builder.Build();
        }
        public ClassT Resolve<ClassT>( ) {
            try {
                return this.resolver.Resolve<ClassT>();
            } catch(Exception x) {
                Trace.WriteLine(x);
                throw;
            }
        }
        public void Dispose( ) {
            this.resolver.Dispose();    
        }
    }
}
