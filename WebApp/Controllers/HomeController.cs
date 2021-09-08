using DL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApp.ViewModels;
using IActionResult = Microsoft.AspNetCore.Mvc.IActionResult;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IReviewRepo _reviewRepo;

        public HomeController(ILogger<HomeController> logger, IReviewRepo reviewRepo)
        {

            _logger = logger;
            _reviewRepo = reviewRepo;
        }

        public IActionResult Index()
        {
            

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Signup(IFormCollection collection)
        {

            if (!ModelState.IsValid)
            {
                return View(collection);
            }

            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
