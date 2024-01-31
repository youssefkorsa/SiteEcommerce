using admin.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace admin.Controllers
{
    [Route("/")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [Route("/")]
        public IActionResult Index()
        {
            return View();
        }
        [Route("/shop")]
        [HttpGet]
        public IActionResult Shop()
        {
    
            return View("shop");
        }
        [Route("/About")]
        [HttpGet]
        public IActionResult About()
        {

            return View();
        }

        [Route("/History")]
        [HttpGet]
        public IActionResult History()
        {

            return View();
        }

        [Route("/User")]
        [HttpGet]
        public IActionResult User()
        {
            return View();
        }

        [Route("/User")]
        [HttpPost]
        public IActionResult UserPost()
        {
            return View();
        }


        [Route("/Cart")]
        [HttpGet]
        public IActionResult Cart()
        {
            return View();
        }

        [Route("/Cart")]
        [HttpPost]
        public IActionResult CartPost()
        {
            return View();
        }


    }
}
