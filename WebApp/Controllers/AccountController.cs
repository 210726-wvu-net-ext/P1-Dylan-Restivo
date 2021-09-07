using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebApp.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System.Web;

namespace WebApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly DL.IReviewRepo _reviewRepo;
        private readonly IOptions<List<UserToLogin>> _users;
        public AccountController(IOptions<List<UserToLogin>> users, DL.IReviewRepo reviewRepo)
        {
            _users = users;
            _reviewRepo = reviewRepo;
        }

        //public void LogOut(object sender, EventArgs e)
        //{
        //    FormsAuthentication.SignOut();
        //    Response.Redirect("Login.aspx");
        //}


        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserToLogin userToLogin)
        {
            var user = _reviewRepo.GetAllUsers().Find(c => c.UserName == userToLogin.UserName && c.Password == userToLogin.Password);

            if (!(user is null))
            {
                var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,userToLogin.UserName),
                new Claim("FullName", userToLogin.UserName),
                new Claim(ClaimTypes.Role, "Administrator"),
            };

                var claimsIdentity = new ClaimsIdentity(
                    claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new Microsoft.AspNetCore.Authentication.AuthenticationProperties
                {

                    RedirectUri = "/Home/Index"

                };

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);

                TempData["LoggedInUser"] = "Exists";

                if (user.Id == 1) 
                {
                    TempData["IsAdmin"] = "Exists";
                }
                return View();

            }

            ModelState.AddModelError("", "Invalid login attempt");
            return View(userToLogin);
        }

    }
}
