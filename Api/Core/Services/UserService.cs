using Microsoft.AspNetCore.Http;
using System;
using System.Linq;

namespace Api.Core.Services
{
    public class UserService
    {
        private readonly IHttpContextAccessor _httpContext;

        public UserService(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }

        //public Guid GetId() => Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa0");
        public Guid GetId() => Guid.Parse(_httpContext.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "Id")?.Value);
    }
}
