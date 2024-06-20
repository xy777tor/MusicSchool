using System.ComponentModel.DataAnnotations;

namespace MusicSchool.WebUI.Models;

public class AddEventWindowViewModel
{
    [Required(AllowEmptyStrings = false, ErrorMessage = "Введите название события.")]
    public string Title { get; set; } = null!;
    [Required(ErrorMessage = "Выберите начальную дату.")]
    public DateTime StartDateTime { get; set; } = DateTime.Today;
    [Required(ErrorMessage = "Выберите конечную дату.")]
    public DateTime EndDateTime { get; set; } = DateTime.Today;
}
