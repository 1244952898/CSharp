using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace WebAPI全局错误日志自动记录.Filters
{
    public class JWTAuthorizeAttribute:AuthorizeAttribute
    {
        public JWTAuthorizeAttribute()
        {
        }

        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
           var headers0 = from h in actionContext.Request.Headers where h.Key== "auth" select h.Key.FirstOrDefault();
           var headers1 = actionContext.Request.Headers.Select(x => x.Key.Equals("auth"));

            return null;
        }

        public virtual string GetTokenStringFromHeader(HttpRequestMessage request)
        {
            if (request == null) return null;
            var auth = request.Headers.Authorization;
            if (auth == null) return null;
        }
    }
}