using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vilin.Core.IServer;
using Vilin.Data;
using Vilin.Models;

namespace Vilin.Mvc.Controllers
{
    public class OrderController : Controller
    {
        [Dependency]
        public ITimeProvider Timeprovider { get; set; }

        private IOrderServer orderServer { get; set; }

        public OrderController()
        {}

        public OrderController(IOrderServer orderServer)
        {
            this.orderServer = orderServer;
        }

        //
        // GET: /Order/
        public ActionResult Index()
        {
            DateTime str = Timeprovider.GetCurrentTime(DateTimeKind.Utc);

            OrderModel ob = new OrderModel();

            ob.OrderCode = "C" + DateTime.Now.ToString("ddHHmmsss");
            ob.ProductCode = "001";
            ob.CreateDate = DateTime.Now;

            orderServer.Add(ob);

            IEnumerable<OrderModel> obs = orderServer.GetAllOrder();

            return View();
        }
    }
}
