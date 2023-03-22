using Microsoft.AspNetCore.Mvc;
using MinhaBiblioteca.Models;
using System.Diagnostics;

namespace MinhaBiblioteca.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Biblioteca()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

    }
}