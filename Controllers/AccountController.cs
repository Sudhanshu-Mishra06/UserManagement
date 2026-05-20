using Azure;
using Microsoft.AspNetCore.Mvc;
using UserCrudApp.DBContext;

namespace UserCrudApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext _db;

        public AccountController(AppDbContext db)
        {
            _db = db;
        }

        // Here is my Login Page
        public IActionResult Login()
        {
            return View();
        }

        // here is my Login user method
        [HttpPost]
        public IActionResult Login(string loginId, string password)
        {
            var user = _db.Users
                .FirstOrDefault(u =>
                    u.LoginId == loginId &&
                    u.Password == password);

            if (user != null)
            {
                Response.Cookies.Append("UserId",
                    user.Id.ToString());

                Response.Cookies.Append("UserName",
                    user.LoginId);

                return RedirectToAction("Dashboard", "Home");
            }

            ViewBag.Error = "Invalid Login";
            return View();
        }

        // here is my Logout user method
        public IActionResult Logout()
        {
            Response.Cookies.Delete("UserId");
            Response.Cookies.Delete("UserName");

            return RedirectToAction("Login");
        }
    }
}
