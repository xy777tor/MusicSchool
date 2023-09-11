using Microsoft.AspNetCore.Mvc;

namespace MusicSchool.WebUI.Controllers;
public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Timesheet()
    {
        return View();
    }
}
