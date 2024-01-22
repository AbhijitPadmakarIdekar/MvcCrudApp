using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MvcCrudApp.Web.Models;
using System.Diagnostics;
using WebApp.Domain.Entities;
using WebApp.Domain.Repository;

namespace MvcCrudApp.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult LoginUser(User user)
        {
            if (user != null && !user.UserName.IsNullOrEmpty())
            {
                var s = _unitOfWork.User.Find(x => x.UserName == user.UserName).ToList<User>();

                if (s.Count > 0 || s != null)
                {
                    if (user.UserName == s[0].UserName && user.Password == s[0].Password)
                    {
                        return RedirectToAction("SearchPage", "Search", new { user.UserName });
                    }
                    else
                    {
                        string customErrorMessage = @$"<h1>Login Failed! Username or Password is wrong!</h1>";
                        return Content(customErrorMessage, "text/html");
                    }
                }
                else
                {
                    string customErrorMessage = @$"<h1>Login Failed! User does not exist!</h1>";
                    return Content(customErrorMessage, "text/html");
                }
            }

            return View(user);
        }

        [HttpGet]
        public IActionResult RegisterUser()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RegisterUser(User user)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.User.Add(user);
                _unitOfWork.SaveChanges();

                return RedirectToAction("Success", "Home");
            }

            return View(user);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Success()
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
