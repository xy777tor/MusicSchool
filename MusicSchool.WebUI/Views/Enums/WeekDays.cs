using System.ComponentModel.DataAnnotations;

namespace MusicSchool.WebUI.Views.Enums;

public enum WeekDays
{
    [Display(Name = "Пн")]
    Monday = 1,
    [Display(Name = "Вт")]
    Tuesday,
    [Display(Name = "Ср")]
    Wednesday,
    [Display(Name = "Чт")]
    Thursday,
    [Display(Name = "Пт")]
    Friday,
    [Display(Name = "Сб")]
    Saturday,
    [Display(Name = "Вс")]
    Sunday
}
