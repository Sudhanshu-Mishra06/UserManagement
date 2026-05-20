using Microsoft.AspNetCore.Mvc;
using UserCrudApp.DBContext;

namespace UserCrudApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _db;

        public HomeController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult Dashboard()
        {
            ViewBag.TotalCredit = _db.UserDetails.Sum(e => e.Credit);
            ViewBag.TotalDebit = _db.UserDetails.Sum(e => e.Debit);

            return View();
        }
    }
}
