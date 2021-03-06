﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ys.samples.dataaccess;

namespace ys.samples.infrastructure.entities {
    public interface IUserEntity : IPersistentEntity {
        string Name {
            get;
            set;
        }
        string FirstName {
            get;
            set;
        }
        string LastName {
            get;
            set;
        }
        string Email {
            get;
            set;
        }
    }
    [AppTable("users")]
    internal class User : PersistentEntity, IUserEntity {
        [Index("IX_NAME", IsUnique =true)]
        [StringLength(50)]
        public string Name {
            get; set;
        }
        [StringLength(50)]
        public string FirstName {
            get;set;
        }
        [StringLength(50)]
        public string LastName {
            get; set;
        }
        [StringLength(50)]
        public string Email {
            get; set;
        }
    }
}
