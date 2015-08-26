using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vilin.Common.Atrribute;
using Vilin.Data;
using Vilin.Models;
using Vilin.Mvc.Models;

namespace Vilin.Mvc.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        [MyActionFilter(Name = "Filter Action")]
        public ActionResult Index()
        {
            VilinDBContext context = new VilinDBContext();

            //OrderModel ob = new OrderModel();
            //ob.OrderCode = "O" + DateTime.Now.ToString("mmsss") ;
            //ob.ProductCode = "CN001";
            //context.Set<OrderModel>().Add(ob);
            //context.SaveChanges();

            List<OrderModel> obs = context.Set<OrderModel>().Where(o => o.Id > 1).ToList();
            obs.FirstOrDefault();

            //IQueryable<OrderModel> obs = context.Set<OrderModel>().Where(o => o.Id > 3);
            //obs.FirstOrDefault();

            return View();
        }

        public ActionResult Add(OrderViewModel req)
        {
            if (!ModelState.IsValid)
            {
                return View(req);
            }

            VilinDBContext context = new VilinDBContext();
            OrderModel ob = new OrderModel();
            ob.OrderCode = req.OrderCode;
            ob.ProductCode = req.ProductCode;
            context.Set<OrderModel>().Add(ob);
            context.SaveChanges();

            OrderModel ob1 = context.Set<OrderModel>().FirstOrDefault();

            return View();
        }
    }
}
