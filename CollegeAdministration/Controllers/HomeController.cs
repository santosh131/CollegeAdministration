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
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            List<Student> lstStudents = new List<Student>();
            lstStudents.Add(new Student() { StudentId=1, Name="Samuel", ActiveInd=true, Address="123 Ljj Ave", Mobile="121313" });
            return View(lstStudents);
        }
    }
}
