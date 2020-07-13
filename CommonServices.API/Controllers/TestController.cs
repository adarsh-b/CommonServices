using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CommonServices.API.Controllers
{
    public class TestController : ApiController
    {
        [HttpGet]
        public string Method1([FromUri] string param)
        {
            // var handler = new JwtSecurityTokenHandler();
            //var jwtSecurityToken = handler.ReadJwtToken(accessToken);
            //var tokenClaims = jwtSecurityToken.Claims;
            return "Your parameter value is: " + param;
        }

        [HttpGet]
        [Authorize]
        public string Method2([FromUri] string param)
        {
            //var handler = new JwtSecurityTokenHandler();
            //var jwtSecurityToken = handler.ReadJwtToken(accessToken);
            //var tokenClaims = jwtSecurityToken.Claims;

            return "Your parameter value is: " + param;
        }
    }
}
