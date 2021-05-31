using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Semester_Work.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DAL_carshop.Models;
using DAL_carshop.SeedData;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;

namespace Semester_Work.Controllers
{
    public class HomeController : Controller
    {
        private SeedUser seedUser = new SeedUser();
        private readonly List<User> _users;
        private readonly List<Role> _roles;

        public HomeController()
        {
           
            _users = seedUser.GetUsers();
            _roles = seedUser.GetRoles();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(Regist model)
        {
            if (ModelState.IsValid)
            {
                User user =  _users.FirstOrDefault(u => u.Email == model.Email);
                if(user==null)
               {
                    if (model.Password != model.ConfirmPassword)
                    {
                        ModelState.AddModelError("", "Некорректные логин и(или) пароль");
                    }
                    user = new User
                    {
                        Id = _users.Count(),
                        First_name = model.First_Name,
                        Second_name = model.Last_Name,
                        Password = model.Password,//back dolbaeb
                         Email=model.Email,
                        RoleId = 1
                    };
                    seedUser.SetUser(user);
                    await Authenticate(user);
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return View(model);
        }

        public IActionResult Login()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(Login model)
        {
            User user = new User();

            
                user = _users.FirstOrDefault(u => u.Email == model.Email && u.Password == model.Password);

                if (user != null)
                {
                    await Authenticate(user); // аутентификация
                    //use = user;
                    return RedirectToAction("Account",user);
                }
                ModelState.AddModelError("", "Некорректные логин и(или) пароль");
           
            return View();
        }
       

        public IActionResult Account()
        {
            User user = new User();
            user = _users.FirstOrDefault(u => u.Email == User.Identity.Name );
            if (user == null)
            {
                return RedirectToAction("Login");
            }

            return View(user);
        }
        private async Task Authenticate(User user)
        {
 
                // создаем один claim
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email),
                
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.RoleId.ToString())
                
            };
            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);
            // установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }
    }
}
