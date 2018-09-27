using CollegeAdministration.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;

namespace CollegeAdministration
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_AuthenticateRequest(Object sender, EventArgs e)
        {
            if (HttpContext.Current.User != null)
            {
                if (HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    if (HttpContext.Current.User.Identity is FormsIdentity)
                    {
                        FormsIdentity fi = (FormsIdentity)HttpContext.Current.User.Identity as FormsIdentity;
                        FormsAuthenticationTicket tc = fi.Ticket;
                        
                        CustomPrincipal cp = new CustomPrincipal(tc.Name);
                        cp.Menus =new List<string> { "Home", "sample","Student" };
                        cp.UserId =int.Parse( tc.UserData);
                        HttpContext.Current.User = cp;
                    }
                }
            }
        }
    }
}
