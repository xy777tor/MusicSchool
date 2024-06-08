using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MusicSchool.WebUI.Models;

public class AddEventWindowViewModel
{
    [Required(AllowEmptyStrings = false, ErrorMessage = "Введите название события.")]
    public string Title { get; set; } = null!;
    [BindProperty]
    public DateTime StartDateTime { get; set; }
    [BindProperty]
    public DateTime EndDateTime { get; set; }
}
