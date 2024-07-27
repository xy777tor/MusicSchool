using Microsoft.AspNetCore.Mvc;
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
    public IActionResult Add([FromForm] EventWindowViewModel viewModel)
    {
        if (!ModelState.IsValid)
        {
            return PartialView("AddEventWindow", viewModel);
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
    public IActionResult Delete([FromForm] int id, [FromForm] DateTime date)
    {
        if (id == 0 && date == DateTime.MinValue)
        {
            throw new ArgumentException();
        }

        _eventWindowService.Delete(id);

        return GetWeekTimesheetPage(date.ToShortDateString());
    }

    [HttpPost]
    public IActionResult Update([FromForm] EventWindowViewModel viewModel)
    {
        if (!ModelState.IsValid)
        {
            return PartialView("EditEventWindow", viewModel);
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
    public IActionResult PickDate([FromForm] TimesheetViewModel viewModel)
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
