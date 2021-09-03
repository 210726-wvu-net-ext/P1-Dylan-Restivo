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

        //public IActionResult Login(UserViewModel activeUser)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View("Login",activeUser);
        //    }

        //    if (_reviewRepo.LoginWebApp(activeUser.username, activeUser.Password) is true)
        //    {
        //        ViewBag.Username = activeUser.username;
        //        TempData["user"] = activeUser.username;
        //        TempData.Peek("user");
        //        return Redirect("~/Home/Index");
        //    }
        //    else
        //    {
        //        return View("Unable to validate credentials");
        //    }
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Signup(IFormCollection collection)
        {
            // ASP.NET "model binding"
            // - fill in action method parameters with data from the request
            //   (URL path, URL query string, form data, etc.)
            //   based on compatible data type and name.

            // validate all action method parameters as user input
            if (!ModelState.IsValid)
            {
                // if ModelState has errors, that can influence view rendering
                // (the validation tag helpers look at it)
                return View(collection);
                //return View("ErrorMessage", model: "invalid");
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
