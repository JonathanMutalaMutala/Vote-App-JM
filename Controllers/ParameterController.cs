using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Vote_Application_JonathanMutala.Data;
using Vote_Application_JonathanMutala.Models;

namespace Vote_Application_JonathanMutala.Controllers
{
    public class ParameterController : Controller
    {
        private readonly Vote_Application_JonathanMutalaContext _context;
        public ParameterController(Vote_Application_JonathanMutalaContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ManageRole()
        {
            List<Role> lstRoles = new List<Role>();
            return View(lstRoles);
        }
        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateRole(Role AddedRole)
        {
            //Role roles = new Role
            //{
            //    Description = AddedRole.Description,
            //    Name = AddedRole.Name,  

            //};
           

            //_context.Add(roles);

            //_context.SaveChanges(); 
            
            return RedirectToAction("ManageRole");
        }

    }
}
