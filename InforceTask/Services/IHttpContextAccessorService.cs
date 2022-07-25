﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InforceTask.Services
{
    public interface IHttpContextAccessorService
    {
        public string GetUser(IHttpContextAccessor httpContextAccessor);
    }
}
