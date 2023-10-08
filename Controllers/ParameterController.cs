using Microsoft.AspNetCore.Mvc;
using Vote_Application_JonathanMutala.Models;

namespace Vote_Application_JonathanMutala.Controllers
{
    public class ParameterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ManageRole()
        {
            List<Roles> lstRoles = new List<Roles>();
            return View(lstRoles);
        }
        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateRole(Roles AddedRole)
        {

            return RedirectToAction("ManageRole");
        }

    }
}
