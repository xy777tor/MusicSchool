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

        return View(new TimesheetViewModel() { RequiredDay = DateTime.Today });
    }

    [Route("Calendar/Timesheet")]
    public ViewResult Timesheet()
    {
        return View(new TimesheetViewModel() { RequiredDay = DateTime.Today });
    }

    [Route("Calendar/Timesheet/{date}")]
    public ViewResult Timesheet(string date)
    {
        DateTime.TryParse(date, out DateTime dateTime);
        return View(new TimesheetViewModel() { RequiredDay = dateTime });
    }

    [HttpPost]
    public ViewResult PickDate(TimesheetViewModel viewModel)
    {
        return View("Timesheet", viewModel);
    }
}
