using System;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class HelloFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //filterContext.Result = new RedirectResult("/");
            //filterContext.ActionParameters //取action參數
        }
    }
}