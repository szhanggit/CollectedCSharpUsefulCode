using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CacheTry.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<object> list = new List<Object>();

            HttpRuntime.Cache.Insert("key", list);
            HttpContext.Cache["ObjectList"] = list;                 // add
            list = (List<object>)HttpContext.Cache["ObjectList"]; // retrieve
            HttpContext.Cache.Remove("ObjectList");                 // remove

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}