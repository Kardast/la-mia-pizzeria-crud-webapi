﻿using la_mia_pizzeria_static.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace la_mia_pizzeria_static.Controllers
{
    public class GuestController : Controller
    {
        private readonly ILogger<GuestController> _logger;

        public GuestController(ILogger<GuestController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewData["title"] = "Home";
            return View();
        }

        public IActionResult Privacy()
        {
            ViewData["title"] = "Privacy";
            return View();
        }

        public IActionResult About()
        {
            ViewData["title"] = "About";
            return View();
        }

        public IActionResult Details(int id)
        {
            ViewData["title"] = "Dettaglio Pizza";
            return View(id);
        }

        public IActionResult Contact()
        {
            ViewData["title"] = "Contattaci";
            return View();
        }
        public IActionResult Comment(int id)
        {
            ViewData["title"] = "Dettaglio Commento";
            return View(id);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}