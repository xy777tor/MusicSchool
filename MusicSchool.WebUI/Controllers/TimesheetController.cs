using Microsoft.AspNetCore.Mvc;
using MusicSchool.WebUI.Models;

namespace MusicSchool.WebUI.Controllers;
public class TimesheetController : Controller
{
    [HttpPost]
    public string AddEvent(AddEventViewModel model)
    {
        return model.Title;
    }
}
