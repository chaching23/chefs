using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using chefs_dishes.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http; 

namespace chefs_dishes.Controllers
{
    public class HomeController : Controller
    {
        private MyContext dbContext;

        public HomeController(MyContext context)
        {
            dbContext = context;
        }


        [HttpGet("user/{id}")]
        public IActionResult Show(int id)
        {
        var user = dbContext.Users.Include(u => u.CreatedPosts)
            .FirstOrDefault(u => u.UserId ==id);
        return View(user);
        }



        [HttpGet("")]
        public IActionResult AllPosts()
        {
            var posts = dbContext.Posts
            .Include(p => p.Creator)
                // .ThenInclude(u => u.CreatedPosts)
            .Include(p => p.Votes)
                .ThenInclude(u => u.Voter)

            .ToList();
            ViewBag.Users =dbContext.Users.ToList();
            return View(posts);
        }


       [HttpGet("posts/new")]
        public IActionResult NewPost()
        {
            var users = dbContext.Users.ToList();
            ViewBag.Users = users;
            return View();
        }

        

        [HttpGet("dishes")]
        public IActionResult AllDishes()
        {

            return View();
            
        }




        [HttpGet("dishes/new")]
        public IActionResult NewDishes()
        {

            return View();
           
        }




    }
}
