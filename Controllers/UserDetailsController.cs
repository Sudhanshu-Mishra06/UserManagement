using Microsoft.AspNetCore.Mvc;
using UserCrudApp.DBContext;
using UserCrudApp.Models;

namespace UserCrudApp.Controllers
{
    public class UserDetailsController : Controller
    {
        private readonly AppDbContext _context;

        public UserDetailsController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.UserDetails.ToList());
        }

        public IActionResult Adduser()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Adduser(UserDetails entry)
        {
            _context.UserDetails.Add(entry);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult EditUser(int id)
        {
            return View(_context.UserDetails.Find(id));
        }

        [HttpPost]
        public IActionResult EditUser(UserDetails model)
        {
            var existing = _context.UserDetails.Find(model.Id);

            existing.Account = model.Account;
            existing.Narration = model.Narration;
            existing.Credit = model.Credit;
            existing.Debit = model.Debit;

            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
