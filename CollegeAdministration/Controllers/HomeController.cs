using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CollegeAdministration.Infrastructure;
using CollegeAdministration.Models;
using CollegeAdministration.Providers;

namespace CollegeAdministration.Controllers
{
    [CustomAuthorization]
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            throw new Exception("asds");
            ViewBag.Title = "Home Page";
            return View();
        }
    }
}
