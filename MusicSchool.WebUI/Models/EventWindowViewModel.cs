﻿using MusicSchool.WebUI.Models.ValitationAttributes;
using System.ComponentModel.DataAnnotations;

namespace MusicSchool.WebUI.Models;

[Serializable]
public class EventWindowViewModel
{
    public int Id { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage = "Введите название события.")]
    public string Title { get; set; } = null!;

    [Required(ErrorMessage = "Выберите начальную дату.")]
    public DateTime StartDateTime { get; set; } = DateTime.Today;

    [Required(ErrorMessage = "Выберите конечную дату.")]
    [EndDateLater(ErrorMessage = "Дата окончания должна быть позже даты начала.")]
    [EndDateSameDay(ErrorMessage = "Событие должно начинаться и заканчиваться в один день.")]
    public DateTime EndDateTime { get; set; } = DateTime.Today;
}
