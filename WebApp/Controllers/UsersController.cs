﻿using DL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.ViewModels;

namespace WebApp.Controllers
{
    public class UsersController : Controller
    {
        private readonly DL.IReviewRepo _reviewRepo;
        private IReviewRepo object1;
        private ILogger<UsersController> object2;

        public UsersController(object @object, DL.IReviewRepo reviewRepo)
        {
            _reviewRepo = reviewRepo;
        }

        public UsersController(IReviewRepo object1, ILogger<UsersController> object2)
        {
            this.object1 = object1;
            this.object2 = object2;
        }

        // GET: Users
        [Route("Users/Index")]
        public ActionResult Index()
        {
            var users = _reviewRepo.GetAllUsers().ToList();
            return View(users);
        }

        // GET: Users/Details/5
        [Route("Users/Details/{id}")]
        public ActionResult Details(string id)
        {
            var users = _reviewRepo.GetAllUsers().First(u => u.Name == id);
            return View(users);
        }

        // GET: Users/Create
        [Route("Users/Create")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        [HttpPost("Users/Create")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserViewModel viewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(viewModel);
                }

                var user = new Models.Users(viewModel.Name, viewModel.UserName, viewModel.Password);
                _reviewRepo.CreateUser(user);

                TempData["CreatedUser"] = user.Name;
                Log.Debug("Creation successful!");
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                Log.Error("Error: Model stat invalid");
                return View();
            }
        }

        [Route("Users/Edit/{id}")]
        public ActionResult Edit(string id)
        {
            var user = _reviewRepo.GetUserObj(id);
            return View(user);
        }

        // GET: Users/Edit/5
        [HttpPost("Users/Edit/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, Models.Users user, IFormCollection collection)
        {
            try
            {

                _reviewRepo.UpdateUser(id, user);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                Log.Error("Error in User/Edit");
                return View();
            }
        }

        // GET: Users/Delete/5
        [Route("Users/Delete/{id}")]
        public ActionResult Delete(string id)
        {
            var users = _reviewRepo.GetAllUsers().First(x => x.Name == id);
            return View(users);
        }

        // POST: Users/Delete/5
        [HttpPost("Users/Delete/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id, IFormCollection collection)
        {
            try
            {
                _reviewRepo.DeleteRestaurant(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                Log.Error("Error in User/Delete");
                var user = _reviewRepo.GetAllUsers().First(x => x.Name == id);
                return View(user);
            }
        }
    }
}
