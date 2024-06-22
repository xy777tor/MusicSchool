using Microsoft.AspNetCore.Mvc;
using MusicSchool.WebUI.Models;
using MusicSchool.Core;
using MusicSchool.Application;
using Microsoft.CodeAnalysis.Elfie.Extensions;
using System;

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

        if (viewModel.StartDateTime == viewModel.EndDateTime)
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

        return View("Timesheet", new TimesheetViewModel() { RequiredDay = viewModel.StartDateTime.Date });
    }

    [Route("Calendar/Timesheet/{date?}")]
    public ViewResult Timesheet(string date)
    {
        return GetWeekTimesheetPage(date);
    }

    [HttpPost]
    public ViewResult PickDate(TimesheetViewModel viewModel)
    {
        return GetWeekTimesheetPage(viewModel.RequiredDay.ToShortDateString());
    }

    private ViewResult GetWeekTimesheetPage(string date)
    {
        TimesheetViewModel viewModel = new TimesheetViewModel();

        if (string.IsNullOrWhiteSpace(date) || !DateTime.TryParse(date, out DateTime dateTime))
        {
            viewModel.RequiredDay = DateTime.Today;
        }
        else
        {
            viewModel.RequiredDay = dateTime;
        }

        List<EventWindow> eventWindows = _eventWindowService.GetWeekEvents(viewModel.GetMonday(viewModel.RequiredDay));

        foreach (EventWindow eventWindow in eventWindows)
        {
            viewModel.EventWindows.Add(new EventWindowViewModel()
            {
                EndDateTime = eventWindow.EndDateTime,
                StartDateTime = eventWindow.StartDateTime,
                Title = eventWindow.Title
            });
        }

        return View("Timesheet", viewModel);
    }
}
