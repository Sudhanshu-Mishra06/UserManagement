using Microsoft.AspNetCore.Mvc;
using UserCrudApp.DBContext;
using UserCrudApp.Models;

namespace UserCrudApp.Controllers
{
    public class UsersController : Controller
    {
        private readonly AppDbContext _db;

        public UsersController(AppDbContext db)
        {
            _db = db;
        }

        // User List
        public IActionResult Index()
        {
            return View(_db.Users.ToList());
        }

        // Open Create Page
        public IActionResult CreateUser()
        {
            return View();
        }

        // Save User
        [HttpPost]
        public IActionResult CreateUser(UserLogin u)
        {
            _db.Users.Add(u);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        // Open Edit Page
        public IActionResult UpdateUser(int id)
        {
            var user = _db.Users.Find(id);

            return View(user);
        }

        // Update User
        [HttpPost]
        public IActionResult UpdateUser(UserLogin u)
        {
            var user = _db.Users.Find(u.Id);

            user.LoginId = u.LoginId;
            user.Password = u.Password;

            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        // Delete User
        public IActionResult Delete(int id)
        {
            var user = _db.Users.Find(id);

            _db.Users.Remove(user);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}