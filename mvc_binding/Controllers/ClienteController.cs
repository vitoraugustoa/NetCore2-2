using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using mvc_binding.Models;

namespace mvc_binding.Controllers
{
    public class ClienteController : Controller
    {   
        public IActionResult Index(){

            return View();
        }

        [HttpPost]
        public IActionResult Index(Cliente cliente){
            
            if(cliente?.Id ==0 || cliente?.Nome == null || cliente?.Email == null){
                ViewBag.Erro = "Dados do ciente Inválidos...";
                return View();
           }else{  
                return View("ExibirDados", cliente);
            }
        }

    }
}