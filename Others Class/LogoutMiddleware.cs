using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Vote_Application_JonathanMutala.Others_Class
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class LogoutMiddleware
    {
        private readonly RequestDelegate _next;
       
        public LogoutMiddleware(RequestDelegate next)
        {
            _next = next;
           

        }

        public  async Task Invoke(HttpContext httpContext, SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> UserManager)
        {
            var x = signInManager;
            var a = UserManager;
            //var x = httpContext.Session.
            if (signInManager.Context.User.Identity.IsAuthenticated)
            {
                if (!signInManager.Context.Session.IsAvailable)
                {
                    await signInManager.SignOutAsync();
                }
            }
            await _next(httpContext);
            // return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class LogoutMiddlewareExtensions
    {
        public static IApplicationBuilder UseLogoutMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LogoutMiddleware>();
        }
    }
}
