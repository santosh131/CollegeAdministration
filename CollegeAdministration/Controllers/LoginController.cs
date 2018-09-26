using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using CollegeAdministration.Models;

namespace CollegeAdministration.Controllers
{ 
    public class LoginController : Controller
    {
        // GET: Login
        [AllowAnonymous]
        public ActionResult Index()
        {
            FormsAuthentication.SignOut();
            User u = new User();
            return View(u);
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(User u)
        {
            if(u.UserName=="admin" && u.Password=="test")
            {
                u.Id = 1;
                FormsAuthenticationTicket at = new FormsAuthenticationTicket(1, u.UserName, DateTime.Now, DateTime.Now.AddMinutes(5), true, u.Id.ToString(), FormsAuthentication.FormsCookiePath);
                string encTicket = FormsAuthentication.Encrypt(at);
                HttpCookie hc = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);
                if (at.IsPersistent)
                    hc.Expires = at.Expiration;
                Response.Cookies.Add(hc);
                return new RedirectToRouteResult(new RouteValueDictionary
                (
                     new
                     {
                         controller ="Home",
                         action="Index"
                     }
                ));
            }
            return RedirectToAction("Index");
        }

        [AllowAnonymous]
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }
    }
}