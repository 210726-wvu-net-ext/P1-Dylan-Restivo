using DL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        [Route("Restaurants/Index")]
        public ActionResult Index()
        {
            var restaurants = _reviewRepo.GetAllRestaurants().ToList();
            return View(restaurants);
        }

        // GET: RestaurantsController/Details/5
        [Route("Restaurants/Details/{name}")]
        [Authorize]
        public ActionResult Details(string name)
        {
            var restaurants = _reviewRepo.GetAllRestaurants().First(r => r.Name == name);
            return View(restaurants);
        }

        // GET: RestaurantsController/Create
        [Route("Restaurants/Create")]
        [Authorize]
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

                return RedirectToAction(nameof(Index));
            }
            catch
            {
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
                // ADD ERROR MESSAGE
                var restaurant = _reviewRepo.GetAllRestaurants().First(x => x.Name == id);
                return View(restaurant);
            }
        }
    }
}
