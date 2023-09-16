using Microsoft.AspNetCore.Mvc;
using MusicSchool.WebUI.Models;

namespace MusicSchool.WebUI.Controllers;
public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Timesheet()
    {
        return View(new AddEventViewModel());
    }
}
