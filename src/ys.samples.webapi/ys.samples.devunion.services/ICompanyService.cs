﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ys.samples.services;

namespace ys.samples.devunion {
    public class CompanyModel : TrackedModel {
        public string name {
            get;
            set;
        }
        public string sobriquet {
            get;
            set;
        }
        public string address {
            get;
            set;
        }
    }
    public interface ICompanyService : IDomainService<CompanyModel> {
    }
}
