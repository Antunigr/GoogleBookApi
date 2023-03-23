using Microsoft.AspNetCore.Mvc;
using MinhaBiblioteca.Models;
using MinhaBiblioteca.Services;
using System.Diagnostics;

namespace MinhaBiblioteca.Controllers
{
    public class HomeController : Controller
    {

        public BookApiService bookservice = new BookApiService();

        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("Home/Biblioteca/{nome?}")]
        public async Task<IActionResult> Biblioteca(string? nome)
        {
            if(nome == null)
            {
                List<BookApi> bookApis= new List<BookApi>();
                ViewBag.book = bookApis;
            }
            else
            {
                List<BookApi> data = await bookservice.GetBookName(nome);
              ViewBag.book = data;
            }

          

            return View();

        }

        public IActionResult Login()
        {
            return View();
        }


        public IActionResult Book()
        {
            return View();
        }
    }
}

