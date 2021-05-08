using AdditionBonusTask.Areas.Identity.Data;
using AdditionBonusTask.Data;
using AdditionBonusTask.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AdditionBonusTask.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AuthDbContext _context;
        public HomeController(ILogger<HomeController> logger, AuthDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        // GET: Friends
        public async Task<IActionResult> Friends(string searchString)
        {

            var user = HttpContext.User.Identity;
            var user1 = this._context.Users.FirstOrDefault(u => u.Email==user.Name);
            List<Friend> users = this._context.Friends.Where(f => f.FriendSenderId.Equals(user1.Id.ToString())).ToList();
            

            if (searchString!=null)
            {
                List<ApplicationUser> listUsers = _context.Users.Where(userr => userr.FirstName.Contains(searchString)).ToList();
                List<Friend> users2 = new List<Friend>();
                foreach(var friend in listUsers)
                {
                    foreach(var rec in users)
                    {
                        if (friend.Id.ToString() == rec.ReceiverId)
                        {
                            users2.Add(rec);
                        }
                    }
                }
                users = users2;
            }
                
            return View(users.ToList());
        }

        public IActionResult Messages()
        {
            return View();
        }

        public IActionResult Admin()
        {
            return View();
        }

        public IActionResult Profile()
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
