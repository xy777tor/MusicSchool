﻿using Microsoft.AspNetCore.Mvc;

namespace MusicSchool.WebUI.Controllers;
public class TimesheetController : Controller
{
    public IActionResult TimesheetPage()
    {
        return View();
    }
}
