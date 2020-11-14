using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Logging;
using PathfinderManagement.Business;
using PathfinderManagement.Models;

namespace PathfinderManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly ITextFileOperations _textFileOperations;

        public HomeController(ILogger<HomeController> logger, ITextFileOperations textFileOperations)
        {
            _logger = logger;
            _textFileOperations = textFileOperations;
        }

        public IActionResult Index()
        {
            ViewBag.IndexHeader = "Welcome to Bishopdale Pathfinders";
            //ViewData["IndexHeader"] = "Welcome to Bishopdale Pathfinders";
            ViewData["IndexInfo"] = "This website contains information regarding the Bishopdale Church Pathfinder Club. Leaders are able to log in to the site to view, create, update, or delete data in the databases. This data keeps track of our pathfinders and their progress throughout the years and will make events such as investiture run smoother.";
            ViewData["PathfinderInfo"] = _textFileOperations.LoadPathfinderInfo();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
