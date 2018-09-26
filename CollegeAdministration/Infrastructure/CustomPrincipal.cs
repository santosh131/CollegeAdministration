using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace CollegeAdministration.Infrastructure
{
    public class CustomPrincipal : IPrincipal
    {
        public IIdentity Identity
        {
            get;
            private set;

        }
        public int UserId { get; set; }
        public List<string> Menus { get; set; }

        public CustomPrincipal(string userName)
        {
            Identity = new GenericIdentity(userName);
        }

        public bool IsInRole(string role)
        {
            throw new NotImplementedException();
        }

        public bool HasControllerPermission(string controllerName)
        {
            return this.Menus.Contains(controllerName);
        }
    }
}