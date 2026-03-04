using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using LibraryApp.Models;

namespace LibraryApp.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        int visits = HttpContext.Session.GetInt32("Visits") ?? 0;
        visits++;
        HttpContext.Session.SetInt32("Visits", visits);
        ViewBag.Visits = visits;
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
