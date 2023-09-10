﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Vote_Application_JonathanMutala.Data;
using System.Globalization;

namespace Vote_Application_JonathanMutala.Controllers
{
    public class ElectionController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ILogger<AccountController> _logger;

        private readonly UserManager<IdentityUser> _userManager;
        private readonly IUserStore<IdentityUser> _userStore;
        private readonly IUserEmailStore<IdentityUser> _emailStore;
        private readonly IEmailSender _emailSender;
        private readonly Vote_Application_JonathanMutalaContext _context;

        public ElectionController(SignInManager<IdentityUser> signInManager, ILogger<AccountController> logger,
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
