using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Vote_Application_JonathanMutala.Data;
using System.Globalization;
using Microsoft.Extensions.Localization;
using Microsoft.AspNetCore.Authorization;
using System.Diagnostics.Metrics;
using System.Text.Json;
using Vote_Application_JonathanMutala.Others_Class;
using Newtonsoft.Json;
using Vote_Application_JonathanMutala.ViewModel;

namespace Vote_Application_JonathanMutala.Controllers
{
    [Authorize]
    public class ElectionController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ILogger<AccountController> _logger;

        private readonly UserManager<IdentityUser> _userManager;
        private readonly IUserStore<IdentityUser> _userStore;
        private readonly IUserEmailStore<IdentityUser> _emailStore;
        private readonly IEmailSender _emailSender;
        private readonly Vote_Application_JonathanMutalaContext _context;
        private readonly IStringLocalizer<ElectionController> _stringLocalizer;

        public ElectionController(SignInManager<IdentityUser> signInManager, ILogger<AccountController> logger,
          UserManager<IdentityUser> userManager,
          IUserStore<IdentityUser> userStore,
          IEmailSender emailSender,
          Vote_Application_JonathanMutalaContext context,IStringLocalizer<ElectionController> stringLocalizer)
        {
            _signInManager = signInManager;
            _logger = logger;
            _userManager = userManager;
            _userStore = userStore;
            _emailSender = emailSender;
            _context = context;
            _stringLocalizer = stringLocalizer;
        }

        // GET: ElectionController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ElectionController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ElectionController/Create
        public ActionResult Create()
        {
            var countriesJson = System.IO.File.ReadAllText($"Data/json-country_en.json");
            var countries = System.Text.Json.JsonSerializer.Deserialize<List<Country>>(countriesJson);

           ViewBag.Countries = countries;

            return View();
        }

        // POST: ElectionController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ElectionController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ElectionController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ElectionController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ElectionController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
