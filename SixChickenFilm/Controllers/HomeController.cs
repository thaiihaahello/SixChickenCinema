using Microsoft.AspNetCore.Mvc;
using SixChickenFilm.Models;
using System.Diagnostics;

namespace SixChickenFilm.Controllers
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

        public IActionResult AdminManageShowtime()
        {
            return View();
        }
        public IActionResult AdminManagePromotion()
        {
            return View();
        }

        public IActionResult AdminManageTicket()
        {
            return View();
        }

        public IActionResult AdminManageAffiliate()
        {
            return View();
        }

        public IActionResult AdminManageDiary()
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
