using AutoMapper;
using FitPlaneLife.BusinessLogic;
using FitPlaneLife.BusinessLogic.DBModel;
using FitPlaneLife.BusinessLogic.Interfaces;
using FitPlaneLife.Domain.Entities.User;
using FitPlaneLife.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace FitPlaneLife.Controllers
{
     public class SubscriptionController : Controller
     {
          private readonly ISession _session;
          public SubscriptionController()
          {
               var bl = new BussinessLogic();
               _session = bl.GetSessionBL();
          }
          public ActionResult Index()
          {
               var model = GetSubscriptions();
               return View(model);
          }
          private List<UAbonements> GetSubscriptions()
          {
               return new List<UAbonements>
            {
                new UAbonements { Type = "Monthly", Price = 10, Duration = 1 },
                new UAbonements { Type = "Quarterly", Price = 25, Duration = 3 },
                new UAbonements { Type = "HalfYearly", Price = 45, Duration = 6 }
            };
          }
          public ActionResult Abonements()
          {
               var subscriptions = GetSubscriptions();
               return View(subscriptions);
          }
          public ActionResult Create()
          {
               return View();
          }
          [HttpPost]
          [ValidateAntiForgeryToken]
          public ActionResult Create(Subscription sub)
          {
               if (ModelState.IsValid)
               {
                    var data = Mapper.Map<AbonamentData>(sub);

                    var userSubscription = _session.AddAbonament(data);
                    if (userSubscription.Status)
                    {
                         return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                         ModelState.AddModelError("", userSubscription.StatusMsg);
                         return View();
                    }
               }
               return View();
          }

     }

}
