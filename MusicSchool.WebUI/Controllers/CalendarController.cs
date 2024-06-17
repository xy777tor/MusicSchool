using Microsoft.AspNetCore.Mvc;
using MusicSchool.WebUI.Models;
using MusicSchool.Core;
using MusicSchool.Application;
using Microsoft.CodeAnalysis.Elfie.Extensions;

namespace MusicSchool.WebUI.Controllers;
public class CalendarController : Controller
{
    private readonly IEventWindowService _eventWindowService;

    public CalendarController(IEventWindowService eventWindowService)
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

        TimesheetViewModel timesheetViewModel = new(DateTime.Today);
        return View(timesheetViewModel);
    }

    public ViewResult Timesheet()
    {
        return View(new TimesheetViewModel(DateTime.Today));
    }

    [Route("Calendar/Timesheet/{date}")]
    [HttpPost]
    public ViewResult Timesheet(string date)
    {
        DateTime.TryParse(date, out DateTime dateTime);
        return View(new TimesheetViewModel(dateTime));
    }
}
