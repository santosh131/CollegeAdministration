﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CollegeAdministration.Controllers
{
    public class UnauthorizedController : Controller
    {
        // GET: Unauthorized
        public ActionResult Index()
        {
            return View();
        }
    }
}