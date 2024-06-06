using FitPlaneLife.BusinessLogic;
using FitPlaneLife.BusinessLogic.DBModel;
using FitPlaneLife.BusinessLogic.Interfaces;
using FitPlaneLife.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FitPlaneLife.Controllers
{

    public class HomeController : BaseController
    {
        private readonly ISession _session;
        public HomeController()
        {
            var bl = new BussinessLogic();
            _session = bl.GetSessionBL();
        }
        public void GetCurrentUserAndStatus()
        {
            SessionStatus();
            var apiCookie = System.Web.HttpContext.Current.Request.Cookies["X-KEY"];
            string userStatus = (string)System.Web.HttpContext.Current.Session["LoginStatus"];
            if (userStatus != "guest")
            {
                var profile = _session.GetUserByCookie(apiCookie.Value);
                ViewBag.user = profile;
            }
            ViewBag.userStatus = userStatus;
        }

        public ActionResult Index()
        {
            GetCurrentUserAndStatus();
            return View();
        }
        public ActionResult Contact()
        {
            GetCurrentUserAndStatus();
            return View();
        }

        public ActionResult About()
        {
            GetCurrentUserAndStatus();
            return View();
        }

        public ActionResult Classes()
        {
            GetCurrentUserAndStatus();
            return View();
        }

        public ActionResult Trainers()
        {
            GetCurrentUserAndStatus();
            return View();
        }

        public ActionResult Pages()
        {
            GetCurrentUserAndStatus();
            return View();
        }
        public ActionResult blog_grid()
        {
            GetCurrentUserAndStatus();
            return View();
        }
        public ActionResult blog_detail()
        {
            GetCurrentUserAndStatus();
            return View();
        }
        public ActionResult Testimonial()
        {
            GetCurrentUserAndStatus();
            return View();
        }

        public ActionResult JoinUs()
        {
            GetCurrentUserAndStatus();
            return View();
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
   
}

