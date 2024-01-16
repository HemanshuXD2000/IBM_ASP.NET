using Microsoft.AspNetCore.Mvc;
using OrganicStore.Models;

namespace OrganicStore.Controllers
{
    public class SignupController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(User user)

        {
            User uModel = new User();
            uModel.username = user.username;
            uModel.password = user.password;
            uModel.confpwd = user.confpwd;
            int res = uModel.SaveUserDetails();

            return RedirectToAction("Index", "Home");
        }


    }
}
