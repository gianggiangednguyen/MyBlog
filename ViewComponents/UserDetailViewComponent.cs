using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using MyBlog.Models;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

namespace MyBlog.ViewComponents
{
    public class UserDetailViewComponent : ViewComponent
    {
        private readonly MyBlogDbContext _context;

        public UserDetailViewComponent(MyBlogDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            string id = HttpContext.User.FindFirstValue(ClaimTypes.Sid);

            var acc = await _context.Users.FirstOrDefaultAsync(a => a.UserId == id);

            if (acc != null)
            {
                return View(acc);
            }

            return View(new Users { UserId = "0"});
        }
    }
}
