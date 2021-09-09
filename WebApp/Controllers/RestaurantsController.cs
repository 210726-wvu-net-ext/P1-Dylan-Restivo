using DL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;
using System.Collections.Generic;
using System.Dynamic;
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
        // GET: Restaurant
        public ActionResult Index()
        {
            var restaurants = _reviewRepo.GetAllRestaurants().ToList();
            return View(restaurants);
        }

        // GET: Restaurants/Details/5
        [Route("Restaurants/Details/{name}")]
        
        public ActionResult Details(string name)
        {
            var restaurant = _reviewRepo.GetRestaurantObj(name);

          
            List<Models.Reviews> reviews = _reviewRepo.GetReviewsByRestaurantId(restaurant.Id);

            ViewData["ReviewsList"] = reviews;

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

        // GET: Restaurants/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Restaurants/Create
        [HttpPost]
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
                Log.Debug("Restaurant creation successful!");
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                var error = new Exception();
                Log.Error(error, "An error has occured creating a review restaurant");
                return View();
            }
        }


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
                var error = new Exception();
                Log.Error(error, "An error has occured during Restaurant delete"); ;
                var restaurant = _reviewRepo.GetAllRestaurants().First(x => x.Name == id);
                return View(restaurant);
            }
        }
    }
}