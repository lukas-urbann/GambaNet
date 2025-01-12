using Microsoft.EntityFrameworkCore;
using GambaNet_Web.Infrastructure.Database;
using Pomelo.EntityFrameworkCore.MySql.Internal;
using Microsoft.CodeAnalysis.Diagnostics;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Globalization;
using GambaNet_Web.Application.Abstraction;
using GambaNet_Web.Application.Implementation;
using GambaNet.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

var builder = WebApplication.CreateBuilder(args);

//Culture info
var cultInfo = new CultureInfo("cs-cz");
CultureInfo.DefaultThreadCurrentCulture = cultInfo;
CultureInfo.DefaultThreadCurrentUICulture = cultInfo;

// Add services to the container.
builder.Services.AddControllersWithViews();

string connectionString = builder.Configuration.GetConnectionString("MySQL");
ServerVersion serverVersion = new MySqlServerVersion("8.0.38");
builder.Services.AddDbContext<GambaNetDbContext>(optionsBuilder =>
    optionsBuilder.UseMySql(
        connectionString,
        serverVersion,
        b =>
        {
            b.MigrationsAssembly("GambaNet_Web");
            b.EnableRetryOnFailure();
        }));

builder.Services.AddIdentity<User, Role>()
    .AddEntityFrameworkStores<GambaNetDbContext>()
    .AddDefaultTokenProviders();

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequiredLength = 1;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
    options.Password.RequiredUniqueChars = 1;
    options.Lockout.AllowedForNewUsers = true;
    options.Lockout.MaxFailedAccessAttempts = 10;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);
    options.User.RequireUniqueEmail = true;
});

builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
    options.LoginPath = "/Security/Account/Login";
    options.LogoutPath = "/Security/Account/Logout";
    options.SlidingExpiration = true;
});

builder.Services.AddScoped<IGameAppService, GameAppService>();
builder.Services.AddScoped<IHomeService, HomeService>();
builder.Services.AddScoped<IAccountService, AccountIdentityService>();
builder.Services.AddScoped<IThumbnailUploadService, ThumbnailUploadService>(serviceProvider => new ThumbnailUploadService(serviceProvider.GetService<IWebHostEnvironment>().WebRootPath + "/uploads/"));
builder.Services.AddScoped<IAdService, AdService>();
builder.Services.AddScoped<IBalanceService, BalanceService>();


//Loggovani
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

//app.UseSession();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
