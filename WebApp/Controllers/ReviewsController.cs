using DL;
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


        // GET: ReviewsController
        [Route("Reviews/Index")]
        public ActionResult Index()
        {
            var reviews = _reviewRepo.GetAllReviews();
            return View(reviews);
        }

        // GET: ReviewsController/Details/5
        [Route("Reviews/Details/{id}")]
        public ActionResult Details(int id)
        {
            var reviews = _reviewRepo.GetReviewsByRestaurantId(id);
            return View(reviews);
        }

        // GET: ReviewsController/Create
        [Route("Reviews/Create")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        [HttpPost("Reviews/Create")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(/*string street,*/ ReviewsViewModel viewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(viewModel);
                }
                //try
                //{
                //    _reviewRepo.GetRestaurantObj(street);
                //}

                var review = new Models.Reviews(viewModel.Rating, viewModel.Content);
                _reviewRepo.CreateReview(review);

                TempData["CreatedReview"] = review.Id;
                Log.Debug("Creation successful!");
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                Log.Error("Error: Model stat invalid");
                return View();
            }
        }

        // GET: ReviewsController/Edit/5
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
                Log.Error("Error in Review/Edit");
                return View();
            }
        }

        // GET: ReviewsController/Delete/5
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
                Log.Error("Error in Review/Delete");
                var review = _reviewRepo.GetAllReviews().First(x => x.Id == id);
                return View(review);
            }
        }
    }
}
