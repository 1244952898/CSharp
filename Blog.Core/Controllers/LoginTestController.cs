﻿using Blog.Core.JWT;
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

        [HttpGet]
        public async Task<IActionResult> Login(string returnUrl = null)
        {
            const string Issuer = "https://gov.uk";
            var claims = new List<Claim> {
               new Claim(ClaimTypes.Name,"Andrew",ClaimValueTypes.String,Issuer),
               new Claim(ClaimTypes.Surname,"Lock",ClaimValueTypes.String,Issuer),
               new Claim(ClaimTypes.Country,"UK",ClaimValueTypes.String,Issuer),
               new Claim(ClaimTypes.Surname,"Lock",ClaimValueTypes.String,Issuer),
                new Claim("ChildhoodHero", "Ronnie James Dio", ClaimValueTypes.String)
            };

            var claimIdentity=new ClaimsIdentity(claims,"DriverLicense");
            var claimPrincipal=new ClaimsPrincipal(claimIdentity);

            await HttpContext.SignInAsync("Cookie", claimPrincipal, new AuthenticationProperties
            {
                ExpiresUtc = DateTime.UtcNow.AddMinutes(30),
                IsPersistent = false,
                AllowRefresh = false,
            });

            return RedirectToLocal(returnUrl);
        }
    }
}
