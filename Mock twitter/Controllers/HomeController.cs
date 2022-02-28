using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Mock_twitter.Data_Access;
using Mock_twitter.Entities;
using Mock_twitter.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mock_twitter.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            this.context = context;
        }

        public IActionResult Index()
        {            
            var publisher = context.Publishers                
                .Include(p => p.MainFriendships)
                .ThenInclude(f => f.FriendUser)
                .Include(p => p.Friendships)
                .ThenInclude(f => f.FriendUser)
                .FirstOrDefault(p => p.Id == 1);//id = 1 sadece example kimi
            

            return View();
        }

        [HttpPost]
        public IActionResult Index(User user)
        {
            HttpContext.Session.SetString("userId", user.Id.ToString());
            return View("Index", "Post");
        }


        public IActionResult Register()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
