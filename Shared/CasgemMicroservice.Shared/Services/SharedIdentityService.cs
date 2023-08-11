using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasgemMicroservice.Shared.Services
{
    public class SharedIdentityService : ISharedIdentityService
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        public SharedIdentityService(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }
        public string GetUserID => httpContextAccessor.HttpContext.User.FindFirst("sub").Value;
    }
}
