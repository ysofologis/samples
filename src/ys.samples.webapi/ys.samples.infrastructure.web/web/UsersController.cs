﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using ys.samples.web;

namespace ys.samples.infrastructure.web {
    [RoutePrefix("api/users")]
    public class UsersController : DomainServiceController<IUserService> {
    }
}
