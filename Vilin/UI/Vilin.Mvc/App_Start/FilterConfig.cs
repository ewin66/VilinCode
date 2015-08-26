using System.Web;
using System.Web.Mvc;
using Vilin.Common.Atrribute;

namespace Vilin.Mvc
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());

            // 注册自定义Action过滤器：优先级最低，但是可以作用到所有的控制器和Action
            filters.Add(new MyActionFilterAttribute() { Name = "Global Controller" });
            // 注册自定义Exception过滤器
            filters.Add(new MyExceptionFilterAttribute());
        }
    }
}