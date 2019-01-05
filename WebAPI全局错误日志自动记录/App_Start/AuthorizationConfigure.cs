using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Http;
using Microsoft.IdentityModel.Protocols;
using Microsoft.IdentityModel.Tokens;

namespace WebAPI全局错误日志自动记录.App_Start
{
    public static class AuthorizationConfigure
    {
        public static void SetAuthorization(this HttpConfiguration config)
        {
            //var SymmetricKey= JwtAuthForWebApiConfigurationSection.Current.SymmetricKey;
            //var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(SymmetricKey));
            //config.Filters.Add(new UserAuthorizeAttribute(new TokenValidationParameters()
            //{
            //    IssuerSigningKey = signingKey,
            //    ValidateIssuerSigningKey = true,
            //    ValidateIssuer = false,
            //    ValidateLifetime = false,
            //    ValidateAudience = false,
            //    ClockSkew = TimeSpan.Zero
            //}));
        }
    }
}