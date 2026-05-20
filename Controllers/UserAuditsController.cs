using Microsoft.AspNetCore.Mvc;
using UserCrudApp.DBContext;

namespace UserCrudApp.Controllers
{
    public class UserAuditsController : Controller
    {
        private readonly AppDbContext _db;

        public UserAuditsController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var logs = _db.UserAudits.ToList();
            return View(logs);
        }
    }
}
