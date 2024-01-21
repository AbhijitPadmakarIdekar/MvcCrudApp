using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
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
        public IActionResult SearchPage(string? username)
        {
            SearchParameter searchParameters = new SearchParameter();

            if (!username.IsNullOrEmpty())
            {
                var s = _unitOfWork.SearchParameter.Find(x => x.Username == username).ToList<SearchParameter>();
                if (s.Count > 0) { searchParameters = s[0]; }
            }
            else
            {
                string customErrorMessage = @$"<h1>The string username is null or empty!</h1>";
                return Content(customErrorMessage, "text/html");
            }

            return View(searchParameters);
        }

        [HttpGet]
        public IActionResult SearchEntry()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SubmitEntry(SearchParameter? searchParameter)
        {
            // Your logic to retrieve or generate data
            bool dataToPass = false;
            List<SearchParameter> existingSearchParameter;

            if (searchParameter != null)
            {
                // Get or create the entity
                searchParameter.JsonData = _unitOfWork.SearchParameter.ToJson(searchParameter);
                existingSearchParameter = _unitOfWork.SearchParameter.Find(x => x.Username == searchParameter.Username).ToList<SearchParameter>();
            }
            else
            {
                string customErrorMessage = @$"<h1>The Object searchParameter is null or empty!</h1>";
                return Content(customErrorMessage, "text/html");
            }

            if (existingSearchParameter == null || existingSearchParameter.Count() == 0)
            {
                // If the entity is new (based on the primary key), add it
                _unitOfWork.SearchParameter.Add(searchParameter);
            }
            else
            {
                // If the entity already exists, update it
                for (int i = 0; i < existingSearchParameter.Count; i++)
                {
                    existingSearchParameter[i].Username = searchParameter.Username;
                    existingSearchParameter[i].Fieldname = searchParameter.Fieldname;
                    existingSearchParameter[i].Datatype = searchParameter.Datatype;
                    existingSearchParameter[i].ControlType = searchParameter.ControlType;
                    existingSearchParameter[i].Constraint = searchParameter.Constraint;
                    existingSearchParameter[i].MaxLength = searchParameter.MaxLength;
                    existingSearchParameter[i].MinLimit = searchParameter.MinLimit;
                    existingSearchParameter[i].MaxLimit = searchParameter.MaxLimit;
                    existingSearchParameter[i].MaskPattern = searchParameter.MaskPattern;
                    existingSearchParameter[i].JsonData = searchParameter.JsonData;
                }

                dataToPass = true;
            }

            // Pass the data to the view using ViewBag
            ViewBag.CustomData = dataToPass;

            // Save changes to the database
            _unitOfWork.SaveChanges();

            return View();
        }
    }
}
