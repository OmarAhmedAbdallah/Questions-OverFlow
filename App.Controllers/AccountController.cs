using App.Controllers.Models.UsersDetails;
using App.Data.Models;
using App.Services;
using App.Web.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace App.Controllers.Models.AuthControllers
{
    public class AccountController : Controller
    {
        //public AccountController(ApplicationDbContext context) => _context = context;

        private readonly IUsersDetailsService _usersDetailsService;
        public AccountController(IUsersDetailsService usersDetailsService) => this._usersDetailsService = usersDetailsService;


        // Login Page load
        [AllowAnonymous]
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("userId") != null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        // registration Page load
        public IActionResult Registration()
        {
            if (HttpContext.Session.GetString("userId") != null)
            {
                return RedirectToAction("Index", "Home");
            }
            ViewData["Message"] = "Registration Page";
            return View();
        }


        [HttpPost]
        [Route("/Account/Login")]
        public async Task<ActionResult> Login(LoginFormModel model)
        {
            if (ModelState.IsValid)
            {
                var userdetails = await _usersDetailsService.CheckLogin(model.Email, model.Password);

                if (userdetails == null)
                {
                    ModelState.AddModelError("Password", "Invalid login attempt.");
                    return View("Index");
                }
                HttpContext.Session.SetString("userId", userdetails.Name);
            }
            else
            {
                return View("Index");
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [Route("/Account/Register")]
        public async Task<ActionResult> Register(RegistrationFormModel model)
        {

            if (ModelState.IsValid)
            {
               await _usersDetailsService.RegisterUserDetails(model.Name, model.Email, model.Password, model.Mobile);
            }
            else
            {
                return View("Registration");
            }
            return RedirectToAction("Index", "Account");
        }

     
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return View("Index");
        }

        public void ValidationMessage(string key, string alert, string value)
        {
            try
            {
                TempData.Remove(key);
                TempData.Add(key, value);
                TempData.Add("alertType", alert);
            }
            catch
            {
                Debug.WriteLine("TempDataMessage Error");
            }

        }
    }
}
