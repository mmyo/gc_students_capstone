using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using grand_circus.Models;
using Microsoft.AspNetCore.Http;

namespace grand_circus.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISession _session;
        private readonly GrandCircusContext _context;


        public HomeController(GrandCircusContext context, IHttpContextAccessor httpContextAccessor)
        {
            _session = httpContextAccessor.HttpContext.Session;
            _context = context;
            
        }

        public IActionResult Index()
        {
            var users = _context.User;

            return View(users);


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


        public IActionResult SetUserSession(int id)
        {

            _session.SetInt32("userId", id);

            var loggedInUser = _context.User.Find(id);

            if (loggedInUser.Type == "Student")
            {
                return RedirectToAction("SearchCoursesByUserId", "UserCourses", new { arg = _session.GetInt32("userId") });

            }
            else
            {
                return View("AdminMenu");
            }

        }

        public IActionResult StudentMenu()
        {
            return View();
        }

        public IActionResult AdminMenu()
        {

            return View();


        }
    }
}
