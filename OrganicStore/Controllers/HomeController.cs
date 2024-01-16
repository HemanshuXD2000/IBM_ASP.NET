using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OrganicStore.Models;
using System.Diagnostics;

namespace OrganicStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Signup()
        {
            return View();
        }


        [HttpGet]
        public IActionResult Products()
        {
            
            string productsJson = TempData["products"] as string;
            List<products> res = JsonConvert.DeserializeObject<List<products>>(productsJson);

            ViewData["products"] = res;

            return View(res);
        }

        public IActionResult Cart()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
