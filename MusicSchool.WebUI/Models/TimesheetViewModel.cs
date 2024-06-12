using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MusicSchool.WebUI.Models;

public class TimesheetViewModel
{
    public int GetMonday(DateTime date)
    {
        if (date.DayOfWeek == DayOfWeek.Monday)
        {
            return date.Day;
        }
        else if (date.DayOfWeek < DayOfWeek.Monday)
        {
            return date.Day - 6;
        }
        else
        {
            return date.Day - (date.DayOfWeek - DayOfWeek.Monday);
        }
    }
}
