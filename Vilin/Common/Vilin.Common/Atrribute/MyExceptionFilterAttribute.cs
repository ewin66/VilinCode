using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Vilin.Common.Atrribute
{
    public class MyExceptionFilterAttribute : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            base.OnException(filterContext);
            //获取系统异常消息记录
            string strException = filterContext.Exception.Message;
            if (!string.IsNullOrEmpty(strException))
            {
                //使用Log4Net记录异常信息
                Exception exception = filterContext.Exception;
                if (exception != null)
                {
                    //LogHelper.WriteErrorLog(strException, exception);
                }
                else
                {
                    //LogHelper.WriteErrorLog(strException);
                }
            }

            filterContext.HttpContext.Response.Redirect("~/GlobalErrorPage.html");
        }
    }
}
