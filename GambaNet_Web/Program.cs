using Microsoft.EntityFrameworkCore;
using GambaNet.Infrastructure.Database;
using Pomelo.EntityFrameworkCore.MySql.Internal;
using Microsoft.CodeAnalysis.Diagnostics;
using Microsoft.EntityFrameworkCore.Migrations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

string connectionString = builder.Configuration.GetConnectionString("SEQUEL");
ServerVersion serverVersion = new MySqlServerVersion("8.0.40");
// For later use MySqlOptions options = new MySqlOptions();

builder.Services.AddDbContext<GambaNetDbContext>(optionsBuilder =>
    optionsBuilder.UseMySql(connectionString, serverVersion,
        b => b.MigrationsAssembly("GambaNet_Web")));

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

app.UseRouting();

app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.RunAsync();
