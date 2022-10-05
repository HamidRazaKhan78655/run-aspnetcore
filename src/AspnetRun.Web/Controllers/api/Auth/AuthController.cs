using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AspnetRun.Web.Controllers.api.Auth
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpGet("Login")]
        public IEnumerable<string> Login()
        {
            return new string[] { "value1", "value2" };
        }
        [HttpGet("Logout")]
        public IEnumerable<string> Logout()
        {
            return new string[] { "value1", "value2" };
        }

    }
}
