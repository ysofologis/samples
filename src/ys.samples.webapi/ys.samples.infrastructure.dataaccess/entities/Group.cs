﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ys.samples.dataaccess;

namespace ys.samples.infrastructure.entities {
    [AppTable("groups")]
    public class Group : IPersistentEntity {
        public long Id {
            get;set;
        }
        [Index(IsUnique=true)]
        public string Name {
            get;
            set;
        }
    }
}
