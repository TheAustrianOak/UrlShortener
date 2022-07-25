using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace InforceTask.Services
{
    public class HttpContextAccessorService : IHttpContextAccessorService
    {
        private string userName;
        public string GetUser(IHttpContextAccessor httpContextAccessor)
        {
           return userName = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Name).Value;
        }
    }
}
