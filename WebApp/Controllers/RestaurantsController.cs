using DL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        [Route("/all", Name = "restaurants")]
        public ActionResult Index()
        {
             

            return View(_reviewRepo.GetAllRestaurants());
        }

        // GET: RestaurantsController/Details/5
        public ActionResult Details(int id)
        {
            if (id <=0)
            {
                return NotFound();
            }
            var restaurant = _reviewRepo.GetRestaurantById(id);
            if (restaurant == null)
            {
                return NotFound();
            }
            return View(restaurant);
        }

        // GET: RestaurantsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RestaurantsController/Create
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

        // GET: RestaurantsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RestaurantsController/Edit/5
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

        // GET: RestaurantsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RestaurantsController/Delete/5
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
