using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using Microsoft.IdentityModel.Tokens;

namespace WebAPI全局错误日志自动记录.Filters
{
    public class JWTAuthorizeAttribute:AuthorizeAttribute
    {
        public const string BearerScheme = "Bearer";
        public string CookieNameToCheckForToken { get; set; }
        private TokenValidationParameters _validationParameters;

        public JWTAuthorizeAttribute(TokenValidationParameters parameters)
        {
            _validationParameters = parameters;
        }

        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
           var headers0 = from h in actionContext.Request.Headers where h.Key== "auth" select h.Key.FirstOrDefault();
           var headers1 = actionContext.Request.Headers.Select(x => x.Key.Equals("auth"));

            var request = actionContext.Request;
            string tokenStringFromHeader = GetTokenStringFromHeader(request);
            string tokenStringFromCookie = GetTokenStringFromCookie(CookieNameToCheckForToken);
            string tokenString = tokenStringFromHeader ?? tokenStringFromCookie;

            if (!string.IsNullOrEmpty(tokenStringFromHeader) && !string.IsNullOrEmpty(tokenStringFromCookie))
            {
                var response = request.CreateResponse(HttpStatusCode.Unauthorized, new
                {
                    ErrorCode = (int)HttpStatusCode.Unauthorized,
                    Result = false,
                    Message = "the request need authorization"
                });

                actionContext.Response = response;
                return false;
            }

            if (string.IsNullOrEmpty(tokenString))
            {
                var response = request.CreateResponse(HttpStatusCode.Unauthorized, new
                {
                    ErrorCode = (int)HttpStatusCode.Unauthorized,
                    Result = false,
                    Message = "the request need authorization"
                });
                actionContext.Response = response;
                return false;
            }

            SecurityToken validatedToken;
            var validationParameters = _validationParameters.Clone();
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();



            return null;
        }

        public virtual string GetTokenStringFromHeader(HttpRequestMessage request)
        {
            if (request == null)
                return null;
            var auth = request.Headers.Authorization;
            if (auth == null)
                return null;
            if (!auth.Scheme.Equals(BearerScheme))
            {
                //日志添加
                return null;
            }
            return auth.Parameter;
        }

        protected virtual string GetTokenStringFromCookie(string cookieName)
        {
            if (string.IsNullOrEmpty(cookieName))
                return null;
            var cookie = HttpContext.Current.Request.Cookies[cookieName];
            return cookie?.Name;
        }

    }
}