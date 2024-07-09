﻿using Microsoft.AspNetCore.Mvc;
using MusicSchool.WebUI.Models;
using MusicSchool.Domain;

namespace MusicSchool.WebUI.Controllers;
public class CalendarController : Controller
{
    private readonly IEventWindowService _eventWindowService;

    public CalendarController(IEventWindowService eventWindowService)
    {
        _eventWindowService = eventWindowService;
    }

    [HttpPost]
    public IActionResult AddEvent(EventWindowViewModel viewModel)
    {
        if (!ModelState.IsValid)
        {
            return View("AddEventWindow", viewModel);
        }

        var model = new EventWindow()
        {
            Title = viewModel.Title,
            StartDateTime = viewModel.StartDateTime,
            EndDateTime = viewModel.EndDateTime
        };

        _eventWindowService.Create(model);

        return GetWeekTimesheetPage(model.StartDateTime.ToShortDateString());
    }

    [HttpPost]
    public IActionResult Delete(EventWindowViewModel viewModel)
    {
        if (!ModelState.IsValid)
        {
            return View("EditEventWindow", viewModel);
        }

        var model = new EventWindow()
        {
            Id = viewModel.Id,
            Title = viewModel.Title,
            StartDateTime = viewModel.StartDateTime,
            EndDateTime = viewModel.EndDateTime
        };

        _eventWindowService.Delete(model);

        return GetWeekTimesheetPage(model.StartDateTime.ToShortDateString());
    }

    [HttpPost]
    public IActionResult Update(EventWindowViewModel viewModel)
    {
        if (!ModelState.IsValid)
        {
            return View("EditEventWindow", viewModel);
        }

        var model = new EventWindow()
        {
            Id = viewModel.Id,
            Title = viewModel.Title,
            StartDateTime = viewModel.StartDateTime,
            EndDateTime = viewModel.EndDateTime
        };

        _eventWindowService.Update(model);

        return GetWeekTimesheetPage(model.StartDateTime.ToShortDateString());
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
        TimesheetViewModel viewModel = new();

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
                Id = eventWindow.Id,
                EndDateTime = eventWindow.EndDateTime,
                StartDateTime = eventWindow.StartDateTime,
                Title = eventWindow.Title
            });
        }

        return View("Timesheet", viewModel);
    }
}
