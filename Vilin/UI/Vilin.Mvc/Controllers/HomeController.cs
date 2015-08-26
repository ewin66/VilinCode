using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vilin.Data;
using Vilin.Models;

namespace Vilin.Mvc.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            VilinDBContext context = new VilinDBContext();

            OrderModel ob = new OrderModel();
            ob.OrderCode = "O" + DateTime.Now.ToString("mmsss") ;
            ob.ProductCode = "CN001";
            context.Set<OrderModel>().Add(ob);
            context.SaveChanges();

            OrderModel ob1 = context.Set<OrderModel>().FirstOrDefault();

            return View();
        }

    }
}
