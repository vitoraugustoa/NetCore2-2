using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutenticacaoCookies.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace AutenticacaoCookies.Controllers
{
    public class SegurancaController : Controller
    {
        public IActionResult Login(string requestPath)
        {
            ViewBag.RequestPath = requestPath ?? "/";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel login)
        {
            if (!ValidaLogin(login.Usuario , login.Senha))
                return View();

            // Cria Claims
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, "Vitor"),
                new Claim(ClaimTypes.Email, login.Usuario)
            };

            // Cria um Identity
            ClaimsIdentity identity = new ClaimsIdentity(claims , "cookie");

            // Cria a claims principal
            // Uma implementação do IPrincipal que dá suporte a várias identidades
            ClaimsPrincipal principal = new ClaimsPrincipal(identity);

            // sing-in
            await HttpContext.SignInAsync(
                scheme: "SchemeVitor" ,
                principal: principal ,
                properties: new AuthenticationProperties
                {
                    //IsPersistent = true, // para o recurso 'Lembrar-me'
                    //ExpiresUtc = DateTime.UtcNow.AddMinutes(1) // Tempo de expiração do Cookie
                });

            return Redirect(login.RequestPath ?? "/");
        }

        public async Task<IActionResult> Logout(string requestPath)
        {
            await HttpContext.SignOutAsync(scheme: "SchemeVitor");
            return RedirectToAction("Login");
        }

        public IActionResult AcessoNegado()
        {
            return View();
        }


         private bool ValidaLogin(string usuario , string senha)
        {
            //codigo para acessar um banco de dados
            //e obter as credenciais armazenadas
            return (usuario == "mac" && senha == "numsey");
        }
    }
}