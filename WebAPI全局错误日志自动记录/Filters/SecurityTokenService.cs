using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Web;
using Microsoft.IdentityModel.Tokens;

namespace WebAPI全局错误日志自动记录.Filters
{
    public class SecurityTokenService
    {
        public static string GetToken(int userId,ref string secretKey,string IP, string clientId)
        {
            var now = DateTime.UtcNow;

            var claimList = new List<Claim>
            {
                new Claim("secretKey", secretKey ?? String.Empty),
                new Claim("IP", IP ?? String.Empty),
                new Claim("clientId", clientId ?? String.Empty)
            };
            SecurityKey securityKey=new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey));

            JwtSecurityToken jwt=new JwtSecurityToken(
                claims:claimList.ToArray(),
                notBefore:now,
                expires:now.Add(TimeSpan.FromSeconds(60 * 30)),
                signingCredentials:new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256)
                );

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }
    }
}