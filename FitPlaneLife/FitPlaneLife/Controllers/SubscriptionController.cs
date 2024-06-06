using FitPlaneLife.BusinessLogic.DBModel;
using FitPlaneLife.Domain.Entities.User;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
            var model = Subscriptions();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
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
        private IEnumerable<FitPlaneLife.Domain.Entities.User.Subscription> Subscriptions()
        {
            var subscriptions = new List<FitPlaneLife.Domain.Entities.User.Subscription>
    {
        new FitPlaneLife.Domain.Entities.User.Subscription { Type = "Monthly", Price = 10, Duration = 1 },
        new FitPlaneLife.Domain.Entities.User.Subscription { Type = "Quarterly", Price = 25, Duration = 3 },
        new FitPlaneLife.Domain.Entities.User.Subscription { Type = "HalfYearly", Price = 45, Duration = 6 }
    };

            return subscriptions;
        }

        public ActionResult Abonements()
        {
            var subscriptions = Subscriptions();
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
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
    }
public class Subscription
{
    [Required(ErrorMessage = "The email address is required.")]
    [EmailAddress(ErrorMessage = "The email address is not valid.")]
    public string Name { get; set; }
    public string Type { get; set; }
    public decimal Price { get; set; }
    public int Duration { get; set; }
}

