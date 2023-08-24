using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Vote_Application_JonathanMutala.Data;
using Vote_Application_JonathanMutala.Models;
using Vote_Application_JonathanMutala.ViewModel;

namespace Vote_Application_JonathanMutala.Controllers
{
    public class AccountController : Controller
    {

        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ILogger<AccountController> _logger;

        private readonly UserManager<IdentityUser> _userManager;
        private readonly IUserStore<IdentityUser> _userStore;
        private readonly IUserEmailStore<IdentityUser> _emailStore;
        private readonly IEmailSender _emailSender;
        private readonly Vote_Application_JonathanMutalaContext _context;

        public AccountController(SignInManager<IdentityUser> signInManager, ILogger<AccountController> logger,
            UserManager<IdentityUser> userManager,
            IUserStore<IdentityUser> userStore,
            IEmailSender emailSender,
            Vote_Application_JonathanMutalaContext context)
        {
            _signInManager = signInManager;
            _logger = logger;
            _userManager = userManager;
            _userStore = userStore;
            _emailSender = emailSender;
            _context = context;
        }


        [HttpGet]
        public async Task<IActionResult> Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel )
        {
            var result = await _signInManager.PasswordSignInAsync(loginViewModel.Email, loginViewModel.Password, loginViewModel.RememberMe, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                _logger.LogInformation("User logged in.");
                return RedirectToAction("Index", "Home");
            }
            return View(loginViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Register()
        {
           // var x = _context.Users.;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(LoginViewModel loginViewModel)
        {
            var userInfo = new IdentityUser
            {
                Email = loginViewModel.Email,
                UserName = "Jmutala",
            };

            var userResult = await _userManager.CreateAsync(userInfo,loginViewModel.Password);

            if(userResult.Succeeded)
            {
                var SignInResult = await _signInManager.PasswordSignInAsync(userInfo, loginViewModel.Password, false, false);
            }


            return RedirectToAction("Index","Home");
        }




    }
}
