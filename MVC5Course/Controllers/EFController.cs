using MVC5Course.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
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

        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var product = DB.Product.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
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

            //找出validation的exception
            try
            {
                DB.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var err in ex.EntityValidationErrors)
                {
                    foreach (var item in err.ValidationErrors)
                    {
                        throw new DbEntityValidationException(item.PropertyName + "-" + item.ErrorMessage);
                    }
                }
            }
            return RedirectToAction("Index");
        }

        public ActionResult Plus20Per()
        {
            var data = DB.Product;
            //foreach (var item in data)
            //{
            //    if(item.Price.HasValue)
            //    item.Price = item.Price * 1.2m;
            //}

            //DB.SaveChanges();

            DB.Database.ExecuteSqlCommand(@"UPDATE [D:\寶哥MVC\PROJECTS\MVC5COURSE\APP_DATA\FABRICS.MDF].[dbo].[Product]SET Price = Price * 1.2");

            return RedirectToAction("Index");
        }

        //public ActionResult ClientContribution2()
        //{
        //    //var data = DB.Database.SqlQuery<>;

        //    //return View(data);
        //}


        public ActionResult ClientContribution3(string keyword)
        {
            var data = DB.usp_GetClientContribution(keyword);
            return View(data);
        }

        public ActionResult ClientContribution()
        {
            var data = DB.vw_ClientContribution.Take(10);

            return View(data);
        }
    }
}