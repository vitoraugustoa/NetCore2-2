using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SessionNetCore.Models;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Newtonsoft.Json;

namespace SessionNetCore.Controllers
{
    public class HomeController : Controller
    {
        const string SessionKeyName = "_Name";
        const string SessionKeyFY = "_ID";
        const string SessionKeyDate = "_Date";

        public IActionResult Inicio() {
            return View();
        }

        public IActionResult Index()
        {
            // Metodo simples para setar uma session
            HttpContext.Session.SetString(SessionKeyName , "Vitor");
            HttpContext.Session.SetInt32(SessionKeyFY , 125);

            // Metod com objetos mais complexo
            User usuario = new User{
                Id= 10,
                Nome= "Lopes"
            };

            HttpContext.Session.SetString("Usuario" , JsonConvert.SerializeObject(usuario));
            return View();
        }


        public IActionResult Privacy()
        {
            @ViewData["Message"] = "Visualizando as ViewBags ";

            // Buscando variaveis simples de uma session
            ViewBag.Name = HttpContext.Session.GetString(SessionKeyName);
            ViewBag.FY = HttpContext.Session.GetInt32(SessionKeyFY);

            return View();
        }

        public IActionResult Sair()
        {
            ViewData["Message"] = $"Até a proxima {HttpContext.Session.GetString("Vitor")} !"; 
            HttpContext.Session.Remove("Vitor");
            return View();
        }

        public IActionResult Limpar()
        {
            ViewData["Message"] = $"Flww Pessoar!!";

            HttpContext.Session.Clear();
            return View();
        }

        public IActionResult Teste()
        {
            @ViewData["Message"] = "Visualizando o objeto usuario ";

            // Buscando objeto de um session
            var valor = HttpContext.Session.GetString("Usuario");
            if(valor != null)
            {
                User user = JsonConvert.DeserializeObject<User>(valor);
                return View(user);
            }
            else
            {
                return View();
            }
            

            
        }

        [ResponseCache(Duration = 0 , Location = ResponseCacheLocation.None , NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
