using Microsoft.AspNetCore.Mvc;
using WebApp.Domain.Repository;

namespace MvcCrudApp.Web.Controllers
{
    public class SearchController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public SearchController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult SearchEntry()
        {
            return View();
        }

        [HttpGet]
        public IActionResult SearchPage()
        {
            return View();
        }
    }
}
