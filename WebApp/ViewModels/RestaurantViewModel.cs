using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.ViewModels
{
    public class RestaurantViewModel : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
