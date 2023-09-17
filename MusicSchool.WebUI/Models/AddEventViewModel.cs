using System.ComponentModel.DataAnnotations;

namespace MusicSchool.WebUI.Models;

public class AddEventViewModel
{
    [Required(AllowEmptyStrings = false, ErrorMessage = "Введите название события.")]
    public string Title { get; set; } = null!;
}
