using Microsoft.EntityFrameworkCore;
using GambaNet.Infrastructure.Database;
using Pomelo.EntityFrameworkCore.MySql.Internal;
using Microsoft.CodeAnalysis.Diagnostics;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Globalization;
using GambaNet_Web.Application.Abstraction;
using GambaNet_Web.Application.Implementation;

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

builder.Services.AddScoped<IGameAppService, GameAppService>();

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

//app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
