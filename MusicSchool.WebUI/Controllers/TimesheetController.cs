using Microsoft.AspNetCore.Mvc;
using MusicSchool.WebUI.Models;

namespace MusicSchool.WebUI.Controllers;
public class TimesheetController : Controller
{
    [HttpPost]
    public IActionResult AddEvent(AddEventViewModel model)
    {
        if (ModelState.IsValid)
        {
            return Ok(model.Title);
        }

        return View("../Home/Timesheet");
    }
}
