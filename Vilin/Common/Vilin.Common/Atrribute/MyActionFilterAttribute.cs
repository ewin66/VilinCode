using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Vilin.Common.Atrribute
{
    public class MyActionFilterAttribute : ActionFilterAttribute
    {
        public string Name { get; set; }

        /// <summary>
        /// Action 执行之前先执行此方法
        /// </summary>
        /// <param name="filterContext">过滤器上下文</param>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            HttpContext.Current.Response.Write("OnActionExecuting ：" + Name);
        }

        /// <summary>
        /// Action执行之后
        /// </summary>
        /// <param name="filterContext">过滤器上下文</param>
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
            HttpContext.Current.Response.Write("OnActionExecuted ：" + Name);
        }

        /// <summary>
        /// ActionResult执行之前先执行此方法
        /// </summary>
        /// <param name="filterContext">过滤器上下文</param>
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            base.OnResultExecuting(filterContext);
            HttpContext.Current.Response.Write("OnResultExecuting ：" + Name);

        }

        /// <summary>
        /// ActionResult执行之后先执行此方法
        /// </summary>
        /// <param name="filterContext">过滤器上下文</param>
        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            base.OnResultExecuted(filterContext);
            HttpContext.Current.Response.Write("OnResultExecuted ：" + Name);
        }
    }
}
