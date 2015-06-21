using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vilin.Data;

namespace Vilin.Mvc.Controllers
{
    public class OrderController : Controller
    {
        //
        // GET: /Order/

        public ActionResult Index()
        {
            VilinDBContext context = new VilinDBContext();

            return View();
        }

    }
}
