using FitPlaneLife.BusinessLogic.DBModel;
using FitPlaneLife.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FitPlaneLife.Controllers
{
    public class HomeController : BaseController
    {
          // GET: Home
        public ActionResult Index()
        {
            SessionStatus();
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Classes()
        {
            return View();
        }

        public ActionResult Trainers()
        {
            return View();
        }

        public ActionResult Pages()
        {
            return View();
        }
        public ActionResult blog_grid()
        {
            return View();
        }
        public ActionResult blog_detail()
        {
            return View();
        }
        public ActionResult Testimonial()
        {
            return View();
        }

        public ActionResult JoinUs()
        {
            return View();
        }
    }
}
