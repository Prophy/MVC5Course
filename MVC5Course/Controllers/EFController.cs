using MVC5Course.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class EFController : Controller
    {
        FabricsEntities DB = new FabricsEntities();

        // GET: EF
        public ActionResult Index()
        {
            var data = DB.Product.Where(x => x.ProductName.Contains("white"));
            return View(data);
        }

        public ActionResult Create()
        {
            var data = new Product()
            {
                ProductName = "white 我要練習我最大",
                Price = 100,
                Stock = 99,
                Active = true
            };

            DB.Product.Add(data);
            DB.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var data = DB.Product.Find(id);
            DB.OrderLine.RemoveRange(data.OrderLine);//將關聯table刪掉
            DB.Product.Remove(data);
            DB.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var data = DB.Product.Find(id);
            return View(data);
        }

        public ActionResult Edit2(int id)
        {
            var data = DB.Product.Find(id);
            data.ProductName += "!";
            DB.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Plus20Per()
        {
            var data = DB.Product;
            foreach (var item in data)
            {
                if(item.Price.HasValue)
                item.Price = item.Price * 1.2m;
            }

            DB.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}