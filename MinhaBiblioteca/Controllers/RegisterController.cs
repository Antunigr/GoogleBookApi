using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MinhaBiblioteca.Models;
using MinhaBiblioteca.Repository;

namespace MinhaBiblioteca.Controllers
{
    public class RegisterController : Controller
    {

        public IActionResult AddUser()
        {
            return View();
        }

        private readonly IRegisterCrud _registerRepository;
        public RegisterController(IRegisterCrud registerRepository)
        {
            _registerRepository = registerRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<RegisterModel>> GetUser()
        {
            return await _registerRepository.Get();
        }


        [HttpPost]
        [Route("/Register/addUser")]
        [AllowAnonymous]
        public async Task<IActionResult> AddUser(RegisterModel model)
        {
            await _registerRepository.Create(model);
            return View();



        }
    }
}

