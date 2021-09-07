using DL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.ViewModels;

namespace WebApp.Controllers
{
    public class RestaurantsController : Controller
    {
        private readonly IReviewRepo _reviewRepo;

        public RestaurantsController(IReviewRepo reviewRepo)
        {
            _reviewRepo = reviewRepo;
        }
        // GET: RestaurantsController
        [Authorize]
        public ActionResult Index()
        {
            var restaurants = _reviewRepo.GetAllRestaurants().ToList();
            return View(restaurants);
        }

        // GET: RestaurantsController/Details/5
        [Route("Restaurants/Details/{name}")]
        
        public ActionResult Details(string name)
        {
            var restaurant = _reviewRepo.GetRestaurantObj(name);
            List<Models.Reviews> reviews = _reviewRepo.GetReviewsByRestaurantId(restaurant.Id);

            ViewBag.RestaurantNow = new Models.Restaurant()
            {
                Name = restaurant.Name,
                Street = restaurant.Street,
                ZipCode = restaurant.ZipCode,
                Cuisine = restaurant.Cuisine,
                Id = restaurant.Id,
            };

            return View(restaurant);
    }

        // GET: RestaurantsController/Create  
        [Route("Restaurants/Create")]
        
        public ActionResult Create()
        {
            return View();
        }

        // POST: Restaurants/Create
        [HttpPost("Restaurants/Create")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RestaurantViewModel viewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(viewModel);
                }

                var restaurant = new Models.Restaurant(viewModel.Name, viewModel.ZipCode, viewModel.Street, viewModel.Cuisine);
                _reviewRepo.CreateRestaurant(restaurant);

                TempData["CreatedRestaurant"] = restaurant.Name;
                Log.Debug("Creation successful!");
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                Log.Error("Error: Model stat invalid");
                return View();
            }
        }

        //[Route("Restaurants/Edit/{id}")]
        //public ActionResult Edit(string id)
        //{
        //    var restaurant = _reviewRepo.GetRestaurantObj(id);
        //    return View(restaurant);
        //}

        //// GET: Restaurants/Edit/5
        //[HttpPost("Restaurants/Edit/{id}")]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(string id, Models.Restaurant restaurant, IFormCollection collection)
        //{
        //    try
        //    {

        //        _reviewRepo.UpdateRestaurant(id, restaurant);
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        // GET: Restaurants/Delete/5
        [Route("Restaurants/Delete/{id}")]
        public ActionResult Delete(string id)
        {
            var restaurant = _reviewRepo.GetAllRestaurants().First(x => x.Name == id);
            return View(restaurant);
        }

        // POST: Restaurants/Delete/5
        [HttpPost("Restaurants/Delete/{id}")]
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
                Log.Error("Error in Restaurant/Delete");
                var restaurant = _reviewRepo.GetAllRestaurants().First(x => x.Name == id);
                return View(restaurant);
            }
        }
    }
}