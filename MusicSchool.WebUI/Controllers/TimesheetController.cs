using Microsoft.AspNetCore.Mvc;
using MusicSchool.WebUI.Models;
using MusicSchool.Core;
using MusicSchool.Application;

namespace MusicSchool.WebUI.Controllers;
public class TimesheetController : Controller
{
    private readonly IEventWindowService _eventWindowService;

    public TimesheetController(IEventWindowService eventWindowService)
    {
        _eventWindowService = eventWindowService;
    }

    [HttpPost]
    public IActionResult AddEvent(AddEventWindowViewModel viewModel)
    {
        if (!ModelState.IsValid)
        {
            return Redirect("~/Home/Error");
        }

        var model = new EventWindow()
        {
            Title = viewModel.Title,
            StartDateTime = viewModel.StartDateTime,
            EndDateTime = viewModel.EndDateTime
        };

        _eventWindowService.Create(model);

        return Redirect("~/Home/Timesheet");
    }
}
