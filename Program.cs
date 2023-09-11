using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Vote_Application_JonathanMutala.Data;
using Vote_Application_JonathanMutala.Others_Class;

var builder = WebApplication.CreateBuilder(args);


var connectionString = builder.Configuration.GetConnectionString("Vote_Application_JonathanMutalaContextConnection") ?? throw new InvalidOperationException("Connection string 'Vote_Application_JonathanMutalaContextConnection' not found.");

builder.Services.AddDbContext<Vote_Application_JonathanMutalaContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<Vote_Application_JonathanMutalaContext>();

builder.Services.AddRazorPages();

#region Session 
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(40);
    options.Cookie.HttpOnly = true;
});
#endregion


#region Authentification Services
builder.Services.Configure<IdentityOptions>(options =>
{
    // Settings Password
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 2;
    options.Password.RequiredUniqueChars = 0;

    // Lockout settings.
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromSeconds(30);
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.AllowedForNewUsers = true;

    // User settings.
    options.User.AllowedUserNameCharacters =
    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
    options.User.RequireUniqueEmail = true;
    
  

});
builder.Services.ConfigureApplicationCookie(options =>
{
    // Cookie settings
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromMinutes(5);
    options.LoginPath = "/Account/Login";
    // options.AccessDeniedPath = "/Identity/Account/AccessDenied";
    options.SlidingExpiration = true;
});

//builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
//        .AddCookie(options =>
//        {
//            options.ExpireTimeSpan = TimeSpan.FromMinutes(2);
//            options.LoginPath = "/Account/Login";
//            options.AccessDeniedPath = "/Auth/AccessDenied";
//        });
#endregion

#region Localization et globalization
builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var supportedCultures = new[] { "en", "fr" };
    options.SetDefaultCulture(supportedCultures[1])
        .AddSupportedCultures(supportedCultures)
        .AddSupportedUICultures(supportedCultures);
});

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddMvc().AddViewLocalization(Microsoft.AspNetCore.Mvc.Razor.LanguageViewLocationExpanderFormat.Suffix);

builder.Services.AddLocalization( options =>
{
    options.ResourcesPath = "Resources";
});
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseRequestLocalization(app.Services.GetRequiredService<IOptions<RequestLocalizationOptions>>().Value);

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();
app.UseMiddleware<LogoutMiddleware>();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
