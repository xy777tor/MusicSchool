using System.ComponentModel.DataAnnotations;

namespace MusicSchool.WebUI.Models;

public class AddEventViewModel
{
    [Required(AllowEmptyStrings = false, ErrorMessage = "Введи название, заебал.")]
    public string Title { get; set; } = null!;
}
