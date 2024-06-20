using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MusicSchool.WebUI.Models;

public class TimesheetViewModel
{
    public AddEventWindowViewModel AddEventWindowViewModel { get; } = new AddEventWindowViewModel();

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
}
