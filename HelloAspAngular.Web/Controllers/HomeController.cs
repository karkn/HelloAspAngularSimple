using HelloAspAngular.Web.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelloAspAngular.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [AjaxOnly]
        public ActionResult Todo()
        {
            return PartialView();
        }

        [AjaxOnly]
        public ActionResult About()
        {
            return PartialView();
        }
    }
}