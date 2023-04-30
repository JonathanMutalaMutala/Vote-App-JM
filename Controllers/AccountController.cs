using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Vote_Application_JonathanMutala.Models;
using Vote_Application_JonathanMutala.ViewModel;

namespace Vote_Application_JonathanMutala.Controllers
{
    public class AccountController : Controller
    {

        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ILogger<AccountController> _logger;

        public AccountController(SignInManager<IdentityUser> signInManager, ILogger<AccountController> logger)
        {
            _signInManager = signInManager;
            _logger = logger;
        }


        [HttpGet]
        public async Task<IActionResult> Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel )
        {
            return View(loginViewModel);
        }
    }
}
