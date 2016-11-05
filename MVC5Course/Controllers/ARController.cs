using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class ARController : BaseController
    {
        // GET: AR
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PPAP()
        {
            var filePath = Server.MapPath("~/Content/ppap.jpg");
            return File(filePath, "image/jpeg");
        }

        public ActionResult JsonTest() {

            db.Configuration.LazyLoadingEnabled = false; //延遲輸出
            //var data = db.All().OrderBy(x => x.ProductId).Take(10);
            var data = db.Product.OrderBy(x => x.ProductId).Take(10);

            return Json(data, JsonRequestBehavior.AllowGet  );
        }
    }
}