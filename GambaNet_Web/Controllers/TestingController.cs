using GambaNet_Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using GambaNet_Web.Application.Abstraction;
using GambaNet_Web.Application.ViewModel;

namespace GambaNet_Web.Controllers;

public class TestingController : Controller
{
    public IActionResult Cups()
    {
        return View();
    }
}