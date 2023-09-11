using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
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
           IdentityUser currentUser = await _userManager.FindByEmailAsync( loginViewModel.Email );

            var result = await _signInManager.PasswordSignInAsync(currentUser, loginViewModel.Password, loginViewModel.RememberMe, lockoutOnFailure: true);

            if (result.Succeeded)
            {
                // _logger.LogInformation("User logged in.");
                // Create claims
                //var claims = new List<Claim>
                //{
                //    new Claim(ClaimTypes.Name, currentUser.UserName),
                //    new Claim(ClaimTypes.Email, currentUser.Email),
                //    // Add other claims as needed
                //};

                //// Set claim expiration time (e.g., 30 minutes from now)
                //var expirationTime = DateTime.UtcNow.AddMinutes(2);

                //// Add a claim for expiration time
                //claims.Add(new Claim(ClaimTypes.Expiration, expirationTime.ToString("yyyy-MM-ddTHH:mm:ssZ")));

                //// Create claims identity
                //var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                //// Create authentication properties
                //var authProperties = new AuthenticationProperties
                //{
                //    AllowRefresh = true, // Allow the user to refresh their authentication session
                //    ExpiresUtc = expirationTime, // Set the expiration time for the authentication cookie
                //};

                //// Sign in the user with the new claims
                //await HttpContext.SignInAsync(
                //    CookieAuthenticationDefaults.AuthenticationScheme,
                //    new ClaimsPrincipal(claimsIdentity),
                //    authProperties);

                return RedirectToAction("Index", "Election");
                
            }
            
            return View(loginViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> LogOut(string returnUrl = null)
        {
            await _signInManager.SignOutAsync();
            // Sign the user out
           // await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Login", "Account");
         
        }


        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Register()
        {
           // var x = _context.Users.;
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Register(LoginViewModel loginViewModel)
        {

            var userInfo = new IdentityUser
            {
                Email = loginViewModel.Email,
                UserName = loginViewModel.UserName,
            };

            var userResult = await _userManager.CreateAsync(userInfo,loginViewModel.Password); // Permet de crée un utilisateur 

            if(userResult.Succeeded)
            {
                await _signInManager.SignInAsync(userInfo, isPersistent: false);
                return RedirectToAction("Index", "Home"); // Redirige ver la page de connexion 
            }

            return View();
           
        }




    }
}
