using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyBlog.Models;
using Microsoft.EntityFrameworkCore;

namespace MyBlog.Controllers
{
    public class HomeController : Controller
    {
        private readonly MyBlogDbContext _context;

        public HomeController(MyBlogDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }
    }
}