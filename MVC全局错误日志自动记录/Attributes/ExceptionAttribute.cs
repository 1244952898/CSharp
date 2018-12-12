using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Common;
using Newtonsoft.Json;

namespace MVC全局错误日志自动记录.Attributes
{
    public class ExceptionAttribute:HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            base.OnException(filterContext);
            string controllerName = filterContext.RouteData.GetRequiredString("controller");
            string actionName = filterContext.RouteData.GetRequiredString("action");
            string message = string.Format
            ("消息类型：{0}<br>消息内容：{1}<br>引发异常的方法：{2}<br>引发异常的对象：{3}<br>堆栈:{4}<br>异常目录：{5}<br>异常文件：{6}",
                filterContext.Exception.GetType().Name,
                filterContext.Exception.Message,
                filterContext.Exception.TargetSite,
                filterContext.Exception.Source,
                filterContext.Exception.StackTrace,
                controllerName,
                actionName);
            Log4NetHelper.LogError(message);
            //处理返回结果
            bool isAjax = filterContext.HttpContext.Request.IsAjaxRequest();
            bool isUpload = filterContext.HttpContext.Request.Files.Count > 0;

            if (isAjax || isUpload)
            {
                //返回统一的Json错误信息
                var scriptSerializer = JsonSerializer.Create(new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
                using (var sw = new StringWriter())
                {
                    scriptSerializer.Serialize(sw, new GenericResult<string> { IsSuccess = false, Message = filterContext.Exception.Message + filterContext.Exception.StackTrace, Tvalue = "" });
                    filterContext.HttpContext.Response.Write(sw.ToString());
                }
                filterContext.HttpContext.Response.End();
            }
            else
            {
                //同步请求 返回操作
                //HandleErrorInfo model = new HandleErrorInfo(filterContext.Exception, controllerName, actionName);
                //ViewResult result = new ViewResult
                //{
                //    ViewName = this.View,
                //    MasterName = this.Master,
                //    ViewData = new ViewDataDictionary<HandleErrorInfo>(model),
                //    TempData = filterContext.Controller.TempData
                //};
                filterContext.HttpContext.Response.Redirect("/Error/Index",true);
                //filterContext.Result = result;
            }

        }
    }
    public class GenericResult<TValue>
    {     /// <summary>
        /// 是否成功
        /// </summary>
        public bool IsSuccess { get; set; }

        /// <summary>
        /// 提示信息
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// 返回值
        /// </summary>
        public TValue Tvalue { get; set; }
    }
}