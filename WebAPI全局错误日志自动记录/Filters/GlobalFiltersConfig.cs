using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Filters;

namespace WebAPI全局错误日志自动记录.Filters
{
    public class GlobalFiltersConfig:IExceptionFilter
    {
        public bool AllowMultiple => true;
        
        public Task ExecuteExceptionFilterAsync(HttpActionExecutedContext actionExecutedContext, CancellationToken cancellationToken)
        {
            Exception ex = actionExecutedContext.Exception;
            RetModelClass retModelClass = new RetModelClass
            {
                Message = ex.Message,
                Source = ex.Source
            };
            actionExecutedContext.Response = actionExecutedContext.Request.CreateResponse(HttpStatusCode.InternalServerError, retModelClass);
           return Task.CompletedTask;
        }

       
    }

    public class RetModelClass
    {
        public string Message { get; set; }
        public string Source { get; set; }
    }
}