using DL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.ViewModels;

namespace WebApp.Controllers
{
    public class UsersController : Controller
    {
        private readonly IReviewRepo _reviewRepo;

        public UsersController(IReviewRepo reviewRepo)
        {
            _reviewRepo = reviewRepo;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(UserViewModel activeUser)
        {
            if (!ModelState.IsValid)
            {
                return View("Login", activeUser);
            }

            if (_reviewRepo.LoginWebApp(activeUser.UserName, activeUser.Password) is true)
            {
                ViewBag.Username = activeUser.UserName;
                TempData["user"] = activeUser.UserName;
                TempData.Peek("user");
                return Redirect("~/Home/Index");
            }
            else
            {
                return View("Error");
            }
        }

        // GET: Users
        public ActionResult Index()
        {
            return View(_reviewRepo.GetAllUsers());
        }

        // GET: Users/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Users/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Users/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
