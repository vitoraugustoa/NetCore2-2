using System;
using Microsoft.AspNetCore.Mvc;


namespace mvcapp1.Controllers
{
    [Route("[Controller]/[action]")]
    public class TesteController : Controller
    {
        public IActionResult Index(){
            ViewData["Saudacao"] = "Olá..."; // Using ViewData
            ViewData["DataInicio"] = new DateTime(2019,01,10);
            ViewBag.Tec = "Utilizando .Net Core 2.2"; // Using ViewBag
            ViewData["Endereco"] = new Endereco() // Passing an object to the ViewData
            {
                Nome = "Vitor",
                Rua = "Rua Projetada, 100",
                Cidade = "Lopes",
                Estado = "MG"
            };

            return View();
        }


    }
}