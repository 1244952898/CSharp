using Blog.Core.JWT;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Blog.Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginTestController : ControllerBase
    {
        [HttpGet]
        public async Task<object> GetJwtStr(string username, string password)
        {
            var jwtModel = new TokenModelJwt()
            {
                Uid = 1,
                Role = "Admin"
            };
            return Ok(new
            {
                success = true,
                token = jwtModel
            });
        }

  
    }
}
