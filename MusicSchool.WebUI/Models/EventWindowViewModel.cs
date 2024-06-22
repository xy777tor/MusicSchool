using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MusicSchool.WebUI.Models;

public class EventWindowViewModel
{
    public required string Title { get; set; }
    public required DateTime StartDateTime { get; set; }
    public required DateTime EndDateTime { get; set; }
}
