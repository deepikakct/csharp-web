using Birthday_Card_generator.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Birthday_Card_generator.Controllers
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

       
        [HttpPost]
        public IActionResult Index(BirthdayCard birthdayCard)
        {
            if (ModelState.IsValid)
            {
                return View("Confirm", birthdayCard);
            }
            else
            {
                return View();
            }
        }


    }
}