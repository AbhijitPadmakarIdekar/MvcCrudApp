using Microsoft.AspNetCore.Mvc;
using WebApp.DataAccess.Implementation;
using WebApp.Domain.Entities;
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

        [HttpPost]
        public IActionResult SubmitSearchEntry(SearchParameter? searchParameter)
        {
            // Get or create the entity
            var existingSearchParameter = _unitOfWork.SearchParameter.GetOrCreate(searchParameter.Username);

            if (existingSearchParameter.SearchParameterId == 0)
            {
                // If the entity is new (based on the primary key), add it
                _unitOfWork.SearchParameter.Add(searchParameter);
            }
            else
            {
                // If the entity already exists, update it
                _unitOfWork.SearchParameter.Update(searchParameter);
            }

            // Save changes to the database
            _unitOfWork.SaveChanges();

            return View("");
        }

        [HttpGet]
        public IActionResult SearchPage()
        {
            return View();
        }
    }
}
