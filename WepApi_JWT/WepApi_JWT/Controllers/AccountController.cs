using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WepApi_JWT.ViewModels;

namespace WepApi_JWT.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginViewModel model)
        {
            // Definindo um email e senha fixos 
            // aqui onde ficara o codigo para buscar os dados do usuario no banco
            // e validar.
            if (model.Email == "vitor.lopes@bhs.com.br" && model.Password == "123")
            {
                return RedirectToAction("Index" , "Home");
            }

            return View();
        }

        [HttpGet]
        public IActionResult Logout()
        {
            return Redirect("/Account/Login");
        }
    }
}