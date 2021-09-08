using DL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.ViewModels;

namespace WebApp.Controllers
{
    public class ReviewsController : Controller
    {
        private readonly IReviewRepo _reviewRepo;

        public ReviewsController(IReviewRepo reviewRepo)
        {
            _reviewRepo = reviewRepo;
        }


        // GET: Reviews
  
        [Route("Reviews/Index")]
        public ActionResult Index()
        {
            var reviews = _reviewRepo.GetAllReviews();
            return View(reviews);
        }

        // GET: Reviews/Details/5
        [Route("Reviews/Details/{id}")]
        public ActionResult Details(int id)
        {
            //var reviews = _reviewRepo.GetReviewsByRestaurantId(ViewBag.RestaurantNow.Id);

            //TempData["ReviewListById"] = reviews;

            return View(/*reviews*/);
        }

        // GET: Reviews/Create
        [Authorize]
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ReviewsViewModel viewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(viewModel);
                }
                int userId = ViewBag.UserNow.Id;
                int restaurantId = ViewBag.RestaurantNow.Id;
                var review = new Models.Reviews(viewModel.Id, viewModel.Rating, viewModel.Content, restaurantId, userId);
                _reviewRepo.CreateReview(review);

                TempData["CreatedReview"] = review.Id;
                Log.Debug("Review creation successful!");
                return RedirectToAction("Restaurants/Details/{restaurantId}");
            }
            catch
            {
                var error = new Exception();
                Log.Error(error, "An error has occured creating a review");
                return View();
            }
        }

        // GET: Reviews/Edit/5
        [Route("Reviews/Edit/{id}")]
        public ActionResult Edit(int id)
        {
            var review = _reviewRepo.GetReviewObj(id);
            return View(review);
        }

        // GET: Reviews/Edit/5
        [HttpPost("Reviews/Edit/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Models.Reviews review, IFormCollection collection)
        {
            try
            {

                _reviewRepo.UpdateReview(id, review);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                var error = new Exception();
                Log.Error(error, "An error has occured during Review edit");
                return View();
            }
        }

        // GET: Reviews/Delete/5
        [HttpPost("Reviews/Delete/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                _reviewRepo.DeleteReview(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                var error = new Exception();
                Log.Error(error, "An error has occured during Review delete");
                var review = _reviewRepo.GetAllReviews().First(x => x.Id == id);
                return View(review);
            }
        }
    }
}
