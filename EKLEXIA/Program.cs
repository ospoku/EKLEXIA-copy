
using AspNetCoreHero.ToastNotification;
using AspNetCoreHero.ToastNotification.Extensions;
using EKLEXIA.Data;
using EKLEXIA.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddMvc();
builder.Services.AddAuthentication();

//  builder.  Services.AddSingleton<IAuthorizationHandler, IncidentAuthorizationHandler>();
//    builder.Services.AddAuthorization(options => options.AddPolicy("sameAuthorPolicy",
//policy =>
//policy.AddRequirements(
//    new SameAuthorRequirement()
//)));
//builder.Services.AddSingleton<IAuthorizationPolicyProvider, PermissionPolicyProvider>();
//builder.Services.AddScoped<IAuthorizationHandler, PermissionAuthorizationHandler>();

// Add services to the container.
builder.Services.AddNotyf(config => { config.DurationInSeconds = 10; config.IsDismissable = true; config.Position = NotyfPosition.BottomRight; });
builder.Services.AddDbContext<XContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ECX")));

builder.Services.AddIdentity<User, AppRole>()
    .AddEntityFrameworkStores<XContext>();
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
}).AddCookie();

builder.Services.AddControllersWithViews();
builder.Services.AddScoped<DBInitializer>();

builder.Services.AddDataProtection();
builder.Services.AddHttpContextAccessor();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseNotyf();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.MapRazorPages();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseCookiePolicy();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

var scope = app.Services.CreateScope();
var db = scope.ServiceProvider.GetRequiredService<XContext>();

  
    db.Database.EnsureCreated();


    var init = scope.ServiceProvider.GetRequiredService<DBInitializer>();
await init.GenderSetup();
await init.MonthSetup();
await init.RegionSetup();
await init.MaritalStatusSetup();
init.RoleCreation(scope.ServiceProvider)
    .Wait();
init.UserCreation(scope.ServiceProvider).Wait();

app.Run();
