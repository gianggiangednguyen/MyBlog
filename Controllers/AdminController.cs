using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using MyBlog.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace MyBlog.Controllers
{
    public class AdminController : Controller
    {
        private readonly MyBlogDbContext _dbcontext;

        public AdminController(MyBlogDbContext context)
        {
            _dbcontext = context;
        }

        public IActionResult Index()
        {
            return View();
        }
       
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            Users acc = await AccountCheck(email, password);

            if (acc != null)
            {
                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Email, acc.Email),
                    new Claim(ClaimTypes.Role, "Admin")
                };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync(principal);
            }

            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();

            return View("Login");
        }

        public async Task<Users> AccountCheck(string email, string password)
        {
            var account = await (from a in _dbcontext.Users
                                 where a.Email == email && a.Password == password
                                 select a).FirstOrDefaultAsync();

            if (!string.IsNullOrEmpty(account.UserId))
            {
                return account;
            }

            return null;
        }
    }
}