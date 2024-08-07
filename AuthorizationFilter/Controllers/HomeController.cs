using AuthorizationFilter.Models;
using AuthorizationFilter.Models.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AuthorizationFilter.Controllers
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

        [CustomAuthorizationFilter("admin")]
        public IActionResult Action1()
        {
            return View();
        }

        [CustomAuthorizationFilter("customer")]
        public IActionResult Action2()
        {
            return View();
        }
    }
}
