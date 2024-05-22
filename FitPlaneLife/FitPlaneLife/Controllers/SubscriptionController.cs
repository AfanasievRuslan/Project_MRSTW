using FitPlaneLife.BusinessLogic.DBModel;
using FitPlaneLife.Domain.Entities.User;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace FitPlaneLife.Controllers
{
    public class SubscriptionController : Controller
    {
        public ActionResult Index()
        {
            // Your logic to retrieve the model data
            var model = GetSubscriptions();
            return View(model);
        }
        public ActionResult CreateBasicSubscription()
        {
            // Implementation for creating a basic subscription
            return View();
        }

        public ActionResult CreatePremiumSubscription()
        {
            // Implementation for creating a premium subscription
            return View();
        }

        // GET: Subscription/Index
        private List<Subscription> GetSubscriptions()
        {
            return new List<Subscription>
            {
                new Subscription { Type = "Monthly", Price = 10, Duration = 1 },
                new Subscription { Type = "Quarterly", Price = 25, Duration = 3 },
                new Subscription { Type = "HalfYearly", Price = 45, Duration = 6 }
            };
        }
        public ActionResult Abonements()
        {
            var subscriptions = GetSubscriptions();
            return View(subscriptions);
        }
        // Acțiuni pentru crearea abonamentelor
        public ActionResult CreateMonthlySubscription() => View("Create");
        public ActionResult CreateQuarterlySubscription() => View("Create");
        public ActionResult CreateHalfYearlySubscription() => View("Create");

        // POST: Subscription/Create
        [HttpPost]
        public ActionResult Create(Subscription model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index"); // Redirecționează la o altă acțiune după salvare
            }
            return View(model);
        }
    }

}
