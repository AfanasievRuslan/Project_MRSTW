using FitPlaneLife.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FitPlaneLife.Controllers
{
    public class AdminController : Controller
    {
        [AdminMode]

        public ActionResult Admin()
        {
            return View();
        }
    }
}