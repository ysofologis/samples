﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ys.samples.services;

namespace ys.samples.web {
    /// <summary>
    /// <see cref="https://spring.io/understanding/HATEOAS"/>
    /// </summary>
    public class HateoasModel {
        public class ResourceLink {
            public string href {
                get;
                set;
            }
            public string rel {
                get;
                set;
            }
        }
        public class ResourceItem {
            public IDomainModel item {
                get;set;
            }
            public IEnumerable<ResourceLink> links {
                get;set;
            }
            public IDictionary<string, string> attributes {
                get;set;
            }
        }
        public class ErrorInfo {
            public string message {
                get;
                set;
            }
            public string type {
                get;
                set;
            }
            public string stackTrace {
                get;
                set;
            }
            public string rootCause {
                get;
                set;
            }
        }
        public IEnumerable<ResourceLink> links {
            get; set;
        }
        public IEnumerable<ResourceItem> content {
            get;set;
        }
        public ErrorInfo error {
            get;
            set;
        }
    }
}
