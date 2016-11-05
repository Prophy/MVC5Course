using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class OrdersController : BaseController
    {
        // GET: Orders
        public ActionResult Index(int clientId)
        {
            var result = db.Client.Where(x => x.ClientId == clientId).ToList();

            return View(result);
        }

        public ActionResult OrderIndex(int clientId)
        {
            var result = db.Order.Where(x => x.ClientId == clientId).Take(10).ToList();

            return View(result);
        }
    }
}