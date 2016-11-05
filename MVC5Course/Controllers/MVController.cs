using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC5Course.Models.ViewModels;
using System.Data.Entity.Validation;

namespace MVC5Course.Controllers
{
    [HandleError(ExceptionType = typeof(DbEntityValidationException), View = "Error_DbEntityValidationException")]
    public class MVController : BaseController
    {
        // GET: MV
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MyForm()
        {

            return View();
        }

        [HttpPost]
        public ActionResult MyForm(ClientViewModel model)
        {

            if (model != null)
            {
                TempData["model"] = model;
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult ProductList()
        {
            var result = db.Product.Where(x => x.IsDeleted == false).OrderByDescending(x=> x.ProductId).Take(10);
            return View(result);
        }

        public ActionResult BatchUpdate(ProductViewModel[] items)
        {
            //if (ModelState.IsValid) //測試,先拿掉
            {
                foreach (var item in items)
                {
                    var product = db.Product.Find(item.ProductId);
                    if (product != null)
                    {
                        product.Price = item.Price;
                        product.ProductName = item.ProductName;
                        product.Stock = item.Stock;
                    }
                }

                db.SaveChanges();
                return RedirectToAction("ProductList");
            }
            return View();
        }

        public ActionResult MyError()
        {
            throw new InvalidOperationException("Error");
            return View();
        }



    }
}