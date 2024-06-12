﻿using Microsoft.AspNetCore.Mvc;
using MusicSchool.WebUI.Models;
using System.Diagnostics;

namespace MusicSchool.WebUI.Controllers;
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Timesheet()
    {
        TimesheetViewModel model = new TimesheetViewModel(DateTime.Today);
        return View(model);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        _logger.LogTrace(HttpContext.TraceIdentifier);
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
