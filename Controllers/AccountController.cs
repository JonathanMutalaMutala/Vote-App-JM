using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

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


        public async Task<IActionResult> Login()
        {
            return View();
        }
    }
}
