using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersonalBlog.Data.Context;
using PersonalBlog.Data.Models;
using PersonalBlog.Data.UnitOfWork;
using PersonalBlog.Web.Models;
using System.Diagnostics;

namespace PersonalBlog.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly PersonalBlogContext _context;
        private readonly UnitOfWork db;



        public HomeController(ILogger<HomeController> logger, PersonalBlogContext context)
        {
            _logger = logger;
            _context = context;
             db = new UnitOfWork(context);

        }

        public IActionResult Index()
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

        public IActionResult AddUser()
        {
            var add = new User
            {
                FName = "User2",
                LName = "Useri",
                IdNumber = "1234567",
                BirthDate = "2001/01/01",
                CreateDate = DateTime.Now,
                Gender = true,
                IsActive = true,
                Maried = false,
                UserName = "Tstuser"
            };
            db.Users.Add(add);
            return View("~/View/Home/Index.cshtml");
        }
    }
}