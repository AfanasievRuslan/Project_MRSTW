using FitPlaneLife.BusinessLogic.DBModel;
using FitPlaneLife.Domain.Entities.User;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace FitPlaneLife.Controllers
{
    public class SubscriptionController : Controller
    {
        private readonly SubscriptionDbContext _context;

        public SubscriptionController(SubscriptionDbContext context)
        {
            _context = context;
        }

        public async Task<ActionResult> Index()
        {
            return View(await _context.Subscriptions.ToListAsync());
        }
        
        public ActionResult Abonements()
        {
            return View();
        }
        public SubscriptionController()
        {
            // Inițializările necesare pot fi realizate aici sau poate fi lăsat gol
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,Description,Price,Duration")] Subscription subscription)
        {
            if (ModelState.IsValid)
            {
                _context.Subscriptions.Add(subscription);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(subscription);
        }

        public ActionResult CreateMonthlySubscription()
        {
            var subscription = new Subscription
            {
                Name = "Monthly Subscription",
                Description = "Access for one month",
                Price = 9.99m,
                Duration = 1 // 1 month
            };
            return View("Create", subscription);
        }

        public ActionResult CreateQuarterlySubscription()
        {
            var subscription = new Subscription
            {
                Name = "Quarterly Subscription",
                Description = "Access for three months",
                Price = 27.99m,
                Duration = 3 // 3 months
            };
            return View("Create", subscription);
        }

       

        public ActionResult CreateHalfYearlySubscription()
        {
            var subscription = new Subscription
            {
                Name = "Half-Yearly Subscription",
                Description = "Access for six months",
                Price = 49.99m,
                Duration = 6 // 6 months
            };
            return View("Create", subscription);
        }

        public ActionResult AbonementsPage()
        {
            return View();
        }

    }
}
