using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using System;

namespace Blog.Core.Controllers
{
    public class LoginHtmlController : Controller
    {

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

            var claimIdentity = new ClaimsIdentity(claims, "DriverLicense");
            var claimPrincipal = new ClaimsPrincipal(claimIdentity);

            await HttpContext.SignInAsync("Cookie", claimPrincipal, new AuthenticationProperties
            {
                ExpiresUtc = DateTime.UtcNow.AddMinutes(30),
                IsPersistent = false,
                AllowRefresh = false,
            });

            return Redirect(returnUrl);
        }
    }
}
