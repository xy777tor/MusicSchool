using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MusicSchool.WebUI.Models;

public class TimesheetViewModel
{
    public EventWindowViewModel EventWindowViewModel { get; set; } = new EventWindowViewModel();

    public List<EventWindowViewModel> EventWindows { get; set; } = new List<EventWindowViewModel>();

    [BindProperty]
    public DateTime RequiredDay { get; set; }

    public DateTime GetMonday(DateTime date)
    {
        if (date.DayOfWeek == DayOfWeek.Monday)
        {
            return date;
        }
        else if (date.DayOfWeek < DayOfWeek.Monday)
        {
            return date.AddDays(-6);
        }
        else
        {
            return date.AddDays(-(date.DayOfWeek - DayOfWeek.Monday));
        }
    }

    public List<EventWindowViewModel> GetEventWindowViewModelsByDate(DateTime date)
    {
        var eventWindows = new List<EventWindowViewModel>();

        eventWindows.AddRange(EventWindows.FindAll(e => e.StartDateTime.Date == date.Date));

        return eventWindows;
    }
}
