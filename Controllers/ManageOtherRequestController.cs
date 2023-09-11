using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;

namespace Vote_Application_JonathanMutala.Controllers
{
    public class ManageOtherRequestController : Controller
    {
        #region Gestion de changement de langues
        [Route("/")]
        [HttpPost]
        public IActionResult ChangeLanguage(string culture, string returnUrl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
            );

            return LocalRedirect(returnUrl);
        }
        #endregion
    }
}
