using FitPlaneLife.BusinessLogic.DBModel;
using FitPlaneLife.Domain.Entities.User;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Web;
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

            [HttpPost]
            [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include ="Id,Name,Description,Price,Duration")] Subscription subscription)
        {
            if (ModelState.IsValid)
                {
                    _context.Subscriptions.Add(subscription);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(subscription);
            }
    }
}